using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TextAssetService.Models;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Serilog;
using TextAssetService.Repository;
using TextAssetService.Service;
using TextAssetService.Services;
using System.Reflection;
using System.IO;
using TextAssetService.Middleware;
using TextAssetService.Utility;

namespace TextAssetService
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            services.AddDbContext<TextAssetDbContext>(options =>
              options.UseNpgsql(connectionString)
            );

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.AddHealthChecks();

            // Used by Serilog correlation-id enricher
            services.AddHttpContextAccessor();

            #region Setup Api Versioning            
            services.AddApiVersioning(
              options =>
              {
                  // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                  options.ReportApiVersions = true;
              });

            services.AddVersionedApiExplorer(
              options =>
              {
                  // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                  // note: the specified format code will format the version as "'v'major[.minor][-status]"
                  options.GroupNameFormat = "'v'VVV";

                  // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                  // can also be used to control the format of the API version in route templates
                  options.SubstituteApiVersionInUrl = true;
              });
            #endregion

            #region Setup Swagger
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddSwaggerGen(
              options =>
              {
                  // add a custom operation filter which sets default values
                  options.OperationFilter<SwaggerDefaultValues>();

                  // Add XML comments to Swagger
                  var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                  var xmlFullPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);

                  if (File.Exists(xmlFullPath))
                  {
                      options.IncludeXmlComments(xmlFullPath);
                  }
                  else
                  {
                      Log.Information("XML documentation file not found at {XmlPath}", xmlFullPath);
                  }

                  // Add api gateway specific settings if deployed outside development 
                  if (!_env.IsDevelopment())
                  {
                      options.DocumentFilter<SwaggerApiGatewayValues>();
                  }
              });
            #endregion

            services.AddTransient<ITextAssetService, TextAssetServiceLayer>();
            services.AddTransient<ITextAssetRepository, TextAssetRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider, IApiVersionDescriptionProvider provider)
        {
            TextAssetDbContext dataContext = serviceProvider.GetService<TextAssetDbContext>();
            dataContext.Database.Migrate();

            String routePrefix = "";
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.SeedDb(development: true);
            }
            else
            {
                app.SeedDb(development: false);
            }

            // Global exception handling
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseSerilogRequestLogging(options =>
            {
                options.EnrichDiagnosticContext = LogHelper.EnrichFromRequest;
                options.GetLevel = LogHelper.ExcludeHealthChecks;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });

            #region Setup Swagger
            app.UseSwagger();

            app.UseSwaggerUI(
                options =>
                {
                    options.DocumentTitle = "Text Asset Service API";

                    // Build a swagger endpoint for each discovered API version.
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"{routePrefix}/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                        Log.Logger.Information("Swagger route prefix: '{Prefix}'. Api Version {@Description}", routePrefix, description);
                    }
                });
            #endregion

            Log.Logger.Information("Web Host Environment: {@Env}", _env);
        }
    }
}

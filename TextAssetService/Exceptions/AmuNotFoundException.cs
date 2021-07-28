using System;
using System.Diagnostics.CodeAnalysis;

namespace TextAssetService.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class AmuNotFoundException:Exception
    {
        public AmuNotFoundException() { }

        public AmuNotFoundException(string msg) : base(msg) { }

        public AmuNotFoundException(string msg, Exception innerException) : base(msg, innerException) { }
    }
}

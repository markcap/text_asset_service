using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TextAssetService.Models
{
    public class TextAsset : Auditable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TextAssetId { get; set; }

        [Required]
        public long FeatureId { get; set; }

        [Required]
        public virtual AssetType AssetType { get; set; }

        [Required]
        public virtual FileType FileType { get; set; }

        [Required]
        public string FileName { get; set; }

        public string Headline { get; set; }

        public string CDNBasePath { get; set; }

        [Required]
        public string TextAssetUuid { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        public DateTime? OriginalDate { get; set; }
    }
}
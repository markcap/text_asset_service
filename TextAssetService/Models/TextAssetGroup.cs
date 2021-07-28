using System;
using System.ComponentModel.DataAnnotations;

namespace TextAssetService.Models
{
    public class TextAssetGroup : Auditable
    {
        [Key]
        public long TextAssetGroupId { get; set; }

        [Required]
        public long FeatureId { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }
    }
}
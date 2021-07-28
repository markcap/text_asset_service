using System.ComponentModel.DataAnnotations;

namespace TextAssetService.Models
{
    public class TextAssetGroupAsset : Auditable
    {
        [Key]
        public long TextAssetGroupAssetId { get; set; }

        [Required]
        public virtual TextAsset TextAsset { get; set; }

        [Required]
        public virtual TextAssetGroup TextAssetGroup { get; set; }

        public long OrderNumber { get; set; }
    }
}
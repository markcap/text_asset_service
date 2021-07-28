using System.ComponentModel.DataAnnotations;

namespace TextAssetService.Models
{
    public class AssetType : Auditable
    {
        [Key]
        public long AssetTypeId { get; set; }

        [Required]
        public string AssetTypeName { get; set; }
    }
}
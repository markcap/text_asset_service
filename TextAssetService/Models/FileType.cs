using System.ComponentModel.DataAnnotations;

namespace TextAssetService.Models
{
    public class FileType : Auditable
    {
        [Key]
        public long FileTypeId { get; set; }

        [Required]
        public string FileTypeName { get; set; }

        [Required]
        public string MimeType { get; set; }
    }
}
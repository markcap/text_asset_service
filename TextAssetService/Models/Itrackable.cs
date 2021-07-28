namespace TextAssetService.Models
{
    using System;

    public interface ITrackable
    {
        DateTime CreatedDate { get; set; }

        string CreatedBy { get; set; }

        DateTime? ModifiedDate { get; set; }

        string ModifiedBy { get; set; }
    }
}
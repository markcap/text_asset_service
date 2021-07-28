using System.Collections.Generic;

namespace TextAssetService.Models
{
    public class TextAssetTopic
    {
        public string TopicName { get; set; }
        public List<TextAsset> TextAssets { get; set; }
    }
}
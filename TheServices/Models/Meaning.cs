using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TheServices.Enums;

namespace TheServices.Models
{
    public class Meaning
    {
        public string Description { get; set; }
        
        [JsonConverter(typeof(StringEnumConverter))]
        public PartOfSpeech PartOfSpeech { get; set; }
        
        public Synonym[] Synonyms { get; set; }
    }
}
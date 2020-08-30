using TheServices.Enums;

namespace TheServices.Models
{
    public class Meaning
    {
        public string Description { get; set; }
        
        public PartOfSpeech PartOfSpeech { get; set; }
        
        public Synonym[] Synonyms { get; set; }
    }
}
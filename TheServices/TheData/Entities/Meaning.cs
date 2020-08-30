namespace TheData.Entities
{
    public class Meaning
    {
        public long Id { get; set; }
        public long WordId { get; set; }
        public string Description { get; set; }
        public string PartOfSpeech { get; set; }
    }
}
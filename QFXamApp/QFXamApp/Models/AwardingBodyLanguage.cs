namespace QFXamApp.Models
{
    public class AwardingBodyLanguage
    {
        public int Id { get; set; }
        public AwardingBody AwardingBody { get; set; }
        public int AwardingBodyId { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}

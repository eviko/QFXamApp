using System.Collections.Generic;

namespace QFXamApp.Models
{
    public class AwardingBody
    {
        public int Id { get; set; }

        public AwardingBodyLanguage ActiveLanguage { get; set; }
        public IList<AwardingBodyLanguage> Languages { get; set; }

        public AwardingBody()
        {
            Languages = new List<AwardingBodyLanguage>();
        }
    }
}

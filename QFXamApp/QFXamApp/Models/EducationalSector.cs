using System.Collections.Generic;

namespace QFXamApp.Models
{
    public class EducationalSector
    {
        public int Id { get; set; }
        
        public EducationalSectorLanguage ActiveLanguage { get; set; }        
        public IList<EducationalSectorLanguage> Languages { get; set; }

        public EducationalSector()
        {
            Languages = new List<EducationalSectorLanguage>();
        }
    }
}
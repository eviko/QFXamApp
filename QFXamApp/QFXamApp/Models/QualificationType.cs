using System.Collections.Generic;

namespace QFXamApp.Models
{
    public class QualificationType
    {
        public int Id { get; set; }

        public int EducationalLevelId { get; set; }
        public EducationalLevel EducationalLevel { get; set; }
        public int EducationalSectorId { get; set; }
        public EducationalSector EducationalSector { get; set; }
        public QualificationTypeLanguage ActiveLanguage { get; set; }
        public IList<QualificationTypeLanguage> Languages { get; set; }

        public QualificationType()
        {
            Languages = new List<QualificationTypeLanguage>();
        }
    }
}

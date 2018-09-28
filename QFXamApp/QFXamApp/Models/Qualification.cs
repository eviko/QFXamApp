using System;
using System.Collections.Generic;
using System.Text;

namespace QFXamApp.Models
{

    public class Qualification
    {
        public int Id { get; set; }

        public int? QualificationTypeId { get; set; }
        public QualificationType QualificationType { get; set; }

        public int? EducationalLevelId { get; set; }
        public EducationalLevel EducationalLevel { get; set; }

        public int? AwardingBodyId { get; set; }
        public AwardingBody AwardingBody { get; set; }
        public QualificationLanguage ActiveLanguage { get; set; }
        public IList<QualificationLanguage> Languages { get; set; }

        public Qualification()
        {
            Languages = new List<QualificationLanguage>();
        }
    }
}

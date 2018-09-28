using System.Collections.Generic;

namespace QFXamApp.Models
{
    public class EducationalLevel
    {
        public int Id { get; set; }

        public int LevelId { get; set; }
        public int EQFLevel { get; set; }
        //public string PickerEdName
        //{
        //    get
        //    {
        //        if (ActiveLanguage != null)
        //            return ActiveLanguage.Name;
        //        return "";
        //    }
        //}

        public EducationalLevelLanguage ActiveLanguage { get; set; }
        public IList<EducationalLevelLanguage> Languages { get; set; }

        public EducationalLevel()
        {
            Languages = new List<EducationalLevelLanguage>();
        }
    }
}

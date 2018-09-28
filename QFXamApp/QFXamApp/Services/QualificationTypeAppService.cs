using Newtonsoft.Json;
using QFXamApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace QFXamApp.Services
{
    public class QualificationTypeAppService
    {
        public static IList<QualificationType> GetQualificationTypes(string language)
        {
            try
            {
                var request = AppServices.CreateNonAuthorizedRequest(Method.GET);
                var finalUri = $"{AppServices.BaseUri}qualificationtype/{language}";

                var client = new RestClient(finalUri);
                //var client = new RestClient($"{AppServices.BaseUri}/{finalUri}");
                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful || response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var qualificationtypes = JsonConvert.DeserializeObject<IList<QualificationType>>(response.Content);
                    return qualificationtypes;
                }

                return new List<QualificationType>();
//                var qftypes = new List<QualificationType>();
//                qftypes.Add(new QualificationType { Id = 1, EducationalLevel = new EducationalLevel() {Id=1, LevelId=47,EQFLevel=1 }, ActiveLanguage = new QualificationTypeLanguage() { QualificationTypeId =47,Name= "ΑΠΟΛΥΤΗΡΙΟ ΔΗΜΟΤΙΚΟΥ"} });
//                qftypes.Add(new QualificationType { Id = 2, EducationalLevel = new EducationalLevel() { Id = 2, LevelId = 51, EQFLevel =4 }, ActiveLanguage = new QualificationTypeLanguage() { QualificationTypeId = 51, Name = "Πτυχίο ΕΠΑΓΓΕΛΜΑΤΙΚΗΣ ΣΧΟΛΗΣ (ΕΠΑ.Σ.)" } });
//                qftypes.Add(new QualificationType { Id = 3, EducationalLevel = new EducationalLevel() { Id = 3, LevelId = 53, EQFLevel = 4 }, ActiveLanguage = new QualificationTypeLanguage() { QualificationTypeId = 53, Name = "Απολυτήριο Επαγγελματικού Λυκείου (ΕΠΑ.Λ.)" } });
//                return qftypes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static QualificationType GetQualificationType(int id, string language)
        {
            var request = AppServices.CreateNonAuthorizedRequest(Method.GET);
            string finalUrl = $"{AppServices.BaseUri}qualificationtype/{language}/{id}";
            var client = new RestClient($"{finalUrl}");
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<QualificationType>(response.Content);
            return null;
//            return (new QualificationType { Id = 3, EducationalLevel = new EducationalLevel() { Id = 3, LevelId = 53, EQFLevel = 28 }, ActiveLanguage = new QualificationTypeLanguage() { QualificationTypeId = 53, Name = "Απολυτήριο Επαγγελματικού Λυκείου (ΕΠΑ.Λ.)" } });
        }
    }
}

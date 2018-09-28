using Newtonsoft.Json;
using QFXamApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace QFXamApp.Services
{
    public class QualificationAppService
    {
        public static IList<Qualification> GetQualifications(string language)
        {
            try
            {
                var request = AppServices.CreateNonAuthorizedRequest(Method.GET);
                var finalUri = $"{AppServices.BaseUri}qualifications/{language}";

                var client = new RestClient(finalUri);
                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful || response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var qualifications = JsonConvert.DeserializeObject<IList<Qualification>>(response.Content);
                    return qualifications;
                }

                return new List<Qualification>();
                //                var qftypes = new List<Qualification>();
                //                qftypes.Add(new Qualification() { Id = 1, QualificationTypeId = 61, EducationalLevelId = 2 , EducationalLevel = new EducationalLevel() { Id = 28, EQFLevel = 4, LevelId = 4 }} );
                //                qftypes.Add(new Qualification() { Id =924, QualificationTypeId = 59, EducationalLevelId = 30, EducationalLevel = new EducationalLevel() { Id = 30, EQFLevel = 6, LevelId = 6 } });
                //
                //                return qftypes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static Qualification GetQualification(int id, string language)
        {
            var request = AppServices.CreateNonAuthorizedRequest(Method.GET);
            string finalUrl = $"{AppServices.BaseUri}qualifications/{language}/{id}";
            var client = new RestClient($"{finalUrl}");
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<Qualification>(response.Content);
            return null;
            //            return (new Qualification() { Id = 1, QualificationTypeId = 61, EducationalLevelId = 2, EducationalLevel = new EducationalLevel() { Id = 28, EQFLevel = 4, LevelId = 4 } });
        }

        public static IList<Qualification> GetQualificationsByCriteria(string language, int? levelId, int? bodyId,
            int? sectorId, int? typeId, string text)
        {
            var queryString = "?";
            if (levelId != null && Convert.ToInt32(levelId) >0 )
            {
                if (queryString.Length > 1)
                    queryString += $"&levelId={Convert.ToInt32(levelId)}";
                else
                    queryString += $"levelId={Convert.ToInt32(levelId)}";
            }            
            if (bodyId != null && Convert.ToInt32(bodyId) > 0)
            {
                if (queryString.Length > 1)
                    queryString += $"&bodyId={Convert.ToInt32(bodyId)}";
                else
                    queryString += $"bodyId={Convert.ToInt32(bodyId)}";
            }

            if (sectorId != null && Convert.ToInt32(sectorId) > 0)
            {
                if (queryString.Length > 1)
                    queryString += $"&sectorId={Convert.ToInt32(sectorId)}";
                else
                    queryString += $"sectorId={Convert.ToInt32(sectorId)}";
            }

            if (typeId != null && Convert.ToInt32(typeId) > 0)
            {
                if (queryString.Length > 1)
                    queryString += $"&typeId={Convert.ToInt32(typeId)}";
                else
                    queryString += $"typeId={Convert.ToInt32(typeId)}";
            }

            if (!string.IsNullOrEmpty(text))
            {
                if (queryString.Length > 1)
                    queryString += $"&text={text}";
                else
                    queryString += $"text={text}";
            }

            var request = AppServices.CreateNonAuthorizedRequest(Method.GET);
            string finalUrl = $"{AppServices.BaseUri}qualifications/filter/{language}{queryString}";
            var client = new RestClient($"{finalUrl}");
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<IList<Qualification>>(response.Content);
            return null;
            //            return (new Qualification() { Id = 1, QualificationTypeId = 61, EducationalLevelId = 2, EducationalLevel = new EducationalLevel() { Id = 28, EQFLevel = 4, LevelId = 4 } });
        }
    }
}

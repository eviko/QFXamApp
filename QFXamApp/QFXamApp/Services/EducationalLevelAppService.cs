using Newtonsoft.Json;
using QFXamApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace QFXamApp.Services
{
    public static class EducationalLevelAppService
    {
        public static IList<EducationalLevel> GetEducationalLevels(string language)
        {
            try
            {
                var request = AppServices.CreateNonAuthorizedRequest(Method.GET);
                var finalUri = $"{AppServices.BaseUri}educationallevel/{language}";

                var client = new RestClient(finalUri);
                //var client = new RestClient($"{AppServices.BaseUri}/{finalUri}");
                IRestResponse response = client.Execute(request);                
                if (response.IsSuccessful || response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var categories = JsonConvert.DeserializeObject<IList<EducationalLevel>>(response.Content);
                    return categories;
                }

                return new List<EducationalLevel>();

//                var edLevels = new List<EducationalLevel>();
//                edLevels.Add(new EducationalLevel { Id = 1, EQFLevel = 1, LevelId = 1,ActiveLanguage=new EducationalLevelLanguage() { Name="name1",Skills="skills1",Knowledge="know1",Competence="comp1"} });
//                edLevels.Add(new EducationalLevel { Id = 2, EQFLevel = 2, LevelId = 2 });
//                edLevels.Add(new EducationalLevel { Id = 3, EQFLevel = 3, LevelId = 3 });
//                return edLevels;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }      

        public static EducationalLevel GetEducationalLevel(int id, string language)
        {
            var request = AppServices.CreateNonAuthorizedRequest(Method.GET);
            string finalUrl = $"{AppServices.BaseUri}educationallevel/{language}/{id}";
            var client = new RestClient($"{finalUrl}");
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
            {
                var level= JsonConvert.DeserializeObject<EducationalLevel>(response.Content);
                return level;
            }
            return null;
//           return (new EducationalLevel { Id = 1, EQFLevel = 1, LevelId = 1, ActiveLanguage = new EducationalLevelLanguage() { Name = "name1", Skills = "skills1", Knowledge = "know1", Competence = "comp1" } });
        }
    }
}

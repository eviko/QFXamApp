using Newtonsoft.Json;
using QFXamApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace QFXamApp.Services
{
    public static class EducationalSectorAppService
    {
        public static IList<EducationalSector> GetEducationalSectors(string language)
        {
            try
            {
                var request = AppServices.CreateNonAuthorizedRequest(Method.GET);
                var finalUri = $"{AppServices.BaseUri}sector/{language}";

                var client = new RestClient(finalUri);
                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful || response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var categories = JsonConvert.DeserializeObject<IList<EducationalSector>>(response.Content);
                    return categories;
                }

                return new List<EducationalSector>();
           }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static EducationalSector GetEducationalSector(int id, string language)
        {
            var request = AppServices.CreateNonAuthorizedRequest(Method.GET);
            string finalUrl = $"{AppServices.BaseUri}sector/{language}/{id}";
            var client = new RestClient($"{finalUrl}");
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<EducationalSector>(response.Content);
            
            return null;
        }
    }
}

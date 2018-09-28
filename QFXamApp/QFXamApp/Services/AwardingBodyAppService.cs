using Newtonsoft.Json;
using QFXamApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace QFXamApp.Services
{
    public static class AwardingBodyAppService
    {
        public static IList<AwardingBody> GetAwardingBodies(string language)
        {
            try
            {
                var request = AppServices.CreateNonAuthorizedRequest(Method.GET);
                var finalUri = $"{AppServices.BaseUri}awardingbodies/{language}";

                var client = new RestClient(finalUri);
                IRestResponse response = client.Execute(request);
                if (response.IsSuccessful || response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var awardingbodies = JsonConvert.DeserializeObject<IList<AwardingBody>>(response.Content);
                    return awardingbodies;
                }

                return new List<AwardingBody>();
//                var awBodies = new List<AwardingBody>();
//                awBodies.Add(new AwardingBody { Id = 1, ActiveLanguage = new AwardingBodyLanguage() { AwardingBodyId=1, Name = "Υπουργείο Οικονομίας, Υποδομών, Ναυτιλίας και Τουρισμού - Ανώτερη Σχολή Τουριστικής Εκπαίδευσης Ρόδο"} });
//                awBodies.Add(new AwardingBody { Id = 2, ActiveLanguage = new AwardingBodyLanguage() { AwardingBodyId = 1, Name = "Υπουργείο Οικονομίας, Υποδομών, Ναυτιλίας και Τουρισμού - Ανώτερη Σχολή Τουριστικής Εκπαίδευσης Κρήτ" } });
//                awBodies.Add(new AwardingBody { Id = 3, ActiveLanguage = new AwardingBodyLanguage() { AwardingBodyId = 1, Name = "ΠΥΡΟΣΒΕΣΤΙΚΗ ΑΚΑΔΗΜΙΑ:  α. Σχολή Ανθυποπυραγών. β. Σχολή Αρχιπυροσβεστών. γ. Σχολή Πυροσβεστών. δ. Σ" } });
//                return awBodies;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static AwardingBody GetAwardingBody(int id, string language)
        {
            var request = AppServices.CreateNonAuthorizedRequest(Method.GET);
            string finalUrl = $"{AppServices.BaseUri}awardingbodies/{language}/{id}";
            var client = new RestClient($"{finalUrl}");
            IRestResponse response = client.Execute(request);
            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<AwardingBody>(response.Content);
             return null;
            //return (new AwardingBody { Id = 1, ActiveLanguage = new AwardingBodyLanguage() { AwardingBodyId = 1, Name = "Υπουργείο Οικονομίας, Υποδομών, Ναυτιλίας και Τουρισμού - Ανώτερη Σχολή Τουριστικής Εκπαίδευσης Ρόδο" } });
        }
    }
}


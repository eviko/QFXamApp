using RestSharp;

namespace QFXamApp.Services
{
    public static class AppServices
    {
        public static string BaseUri => "http://vpierros.ddns.net:845/api/";
        
        public static RestRequest CreateNonAuthorizedRequest(Method httpVerb)
        {
            var request = new RestRequest(httpVerb) { RequestFormat = DataFormat.Json };
            request.AddHeader("Content-Type", "application/json");
            request.Parameters.Clear();
            return request;
        }        
    }
}

using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmadeusApiIntegration.Models
{
    public class GenerateToken
    {
        public string token()
        {
            string url = "https://test.api.amadeus.com/v1/security/oauth2/token";
            string client_id = "ObzQAw791xg97LfX7dprjrkyRMTGlCrH";
            string client_secret = "sGFHJdGcXMiSU5Ap";
            //request token
            var restclient = new RestClient(url);
            RestRequest request = new RestRequest("request/oauth") { Method = Method.Post };
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("client_id", client_id);
            request.AddParameter("client_secret", client_secret);
            request.AddParameter("grant_type", "client_credentials");
            var tResponse = restclient.Execute(request);
            var responseJson = tResponse.Content;
            var token = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson)["access_token"].ToString();
            return token.Length > 0 ? token : null;
        }



    }
}
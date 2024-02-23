using GreekLettersDomain.Services;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace GreekLettersInfrastructure.Services
{
    public class ProblemService : IProblemService
    {
        private readonly string url = "https://tasks.evalartapp.com/api/";
        public async Task<bool> problem(Dictionary<string, List<int>> dictionary)
        {
            try
            {
                var options = new RestClientOptions(url)
                {
                    Authenticator = new HttpBasicAuthenticator("790158", "10df2f32286b7120My0xLTg1MTA5Nw==30e0c83e6c29f1c3")
                };
                var client = new RestClient(options);
                string dictionaryJson = JsonSerializer.Serialize(dictionary);
                var request = new RestRequest("ws/problem").AddJsonBody(dictionaryJson);
                var response = await client.PostAsync(request);
                if (response.IsSuccessStatusCode)
                    return true;
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
    }
}

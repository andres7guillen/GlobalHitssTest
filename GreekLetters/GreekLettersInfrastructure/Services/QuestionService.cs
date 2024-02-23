using GreekLettersDomain.DTO;
using GreekLettersDomain.Services;
using RestSharp.Authenticators;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GreekLettersInfrastructure.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly string url = "https://tasks.evalartapp.com/api/";
        public async Task<int> question(QuestionRequestDTO model)
        {
            var options = new RestClientOptions(url)
            {
                Authenticator = new HttpBasicAuthenticator("790158", "10df2f32286b7120My0xLTg1MTA5Nw==30e0c83e6c29f1c3")
            };
            var client = new RestClient(options);
            string modelJson = JsonSerializer.Serialize(model);
            var request = new RestRequest("ws/question").AddJsonBody(modelJson);
            var response = await client.PostAsync(request);
            if (response.IsSuccessStatusCode) 
            {
                QuestionResponseDTO result = JsonSerializer.Deserialize<QuestionResponseDTO>(response.Content);
                return result.Sum;
            }
            return 0;            
        }
    }
}

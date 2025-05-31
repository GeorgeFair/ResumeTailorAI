using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ResumeTailorAI.Services
{
    public class OpenAiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OpenAiService(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }

        public async Task<string> GenerateResumeSuggestions(string resumeContent)
        {
            var requestBody = new
            {
                prompt = resumeContent,
                max_tokens = 150
            };

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/engines/davinci/completions", 
                new StringContent(JsonConvert.SerializeObject(requestBody), System.Text.Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(jsonResponse);
            return result.choices[0].text;
        }

        public async Task<string> GetAnalysisResults(string resumeContent)
        {
            // Implementation for getting analysis results from OpenAI API
            // This is a placeholder for the actual implementation
            return await Task.FromResult("Analysis results would be here.");
        }
    }
}
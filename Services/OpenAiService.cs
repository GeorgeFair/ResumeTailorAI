using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System.Linq;

namespace ResumeTailorAI.Services
{
    public class OpenAiService
    {
        private readonly HttpClient _httpClient;
        private readonly string? _apiKey;
        private readonly bool _useMockMode;

        public OpenAiService(string? apiKey = null)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
            _useMockMode = string.IsNullOrEmpty(apiKey);
            
            if (!_useMockMode)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            }
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
            dynamic? result = JsonConvert.DeserializeObject(jsonResponse);
            return result?.choices[0]?.text ?? "No response generated.";
        }

        public async Task<string> GetAnalysisResults(string resumeContent)
        {
            // Implementation for getting analysis results from OpenAI API
            // This is a placeholder for the actual implementation
            return await Task.FromResult("Analysis results would be here.");
        }

        public async Task<List<string>> GenerateBulletPoints(string jobDescription)
        {
            if (_useMockMode)
            {
                // Mock bullet points for testing without API key
                await Task.Delay(1000); // Simulate API call delay
                
                var mockBulletPoints = new List<string>
                {
                    "Collaborated with cross-functional teams to deliver high-quality software solutions that exceeded client expectations",
                    "Implemented automated testing processes resulting in 40% reduction in bug reports and improved code quality",
                    "Led technical architecture decisions for scalable applications serving 10,000+ daily active users",
                    "Optimized database performance and reduced query response times by 60% through efficient indexing strategies",
                    "Mentored junior developers and conducted code reviews to maintain coding standards and best practices",
                    "Developed responsive web applications using modern frameworks and achieved 95% client satisfaction rate",
                    "Streamlined deployment processes using CI/CD pipelines, reducing deployment time from hours to minutes"
                };
                
                return mockBulletPoints;
            }

            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new
                    {
                        role = "user",
                        content = $"Based on this job description, generate 5-7 compelling resume bullet points that would be relevant for this position. Focus on achievements, skills, and experiences that align with the requirements:\n\n{jobDescription}"
                    }
                },
                max_tokens = 500,
                temperature = 0.7
            };

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", 
                new StringContent(JsonConvert.SerializeObject(requestBody), System.Text.Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            dynamic? result = JsonConvert.DeserializeObject(jsonResponse);
            
            string content = result?.choices[0]?.message?.content ?? "No response generated.";
            
            // Split the response into bullet points
            var bulletPoints = content.Split('\n')
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Trim().TrimStart('-', '*', '•').Trim())
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .ToList();
            
            return bulletPoints;
        }
    }
}
namespace ResumeTailorAI.Models
{
    public class ResumeAnalysisResult
    {
        public int Score { get; set; }
        public string? Feedback { get; set; }
        public List<string> Suggestions { get; set; }

        public ResumeAnalysisResult()
        {
            Suggestions = new List<string>();
        }
    }
}
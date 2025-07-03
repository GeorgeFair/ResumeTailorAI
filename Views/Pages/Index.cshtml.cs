using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeTailorAI.Models;

public class IndexModel : PageModel
{
    public ResumeAnalysisResult? AnalysisResult { get; set; }
    public void OnGet() { }
    public void OnPost() { }
}
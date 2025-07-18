using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResumeTailorAI.Services;

namespace ResumeTailorAI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly OpenAiService _openAiService;

        public IndexModel(OpenAiService openAiService)
        {
            _openAiService = openAiService;
        }

        [BindProperty]
        public string? JobDescription { get; set; }

        public List<string>? BulletPoints { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrWhiteSpace(JobDescription))
            {
                var result = await _openAiService.GenerateBulletPoints(JobDescription);
                BulletPoints = result;
            }

            return Page();
        }
    }
}

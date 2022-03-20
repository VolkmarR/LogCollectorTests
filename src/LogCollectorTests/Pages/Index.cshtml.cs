using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LogCollectorTests.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogDebug("Simple debug from OnGet");
            _logger.LogInformation("Simple information from OnGet");
            _logger.LogWarning("Simple warning from OnGet");
            _logger.LogError("Simple error from OnGet");
            _logger.LogCritical("Simple critical from OnGet");
        }
    }
}
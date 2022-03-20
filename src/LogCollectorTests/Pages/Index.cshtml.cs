using LogCollectorTests.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LogCollectorTests.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly LogDataHelper _logDataHelper;

        public IndexModel(ILogger<IndexModel> logger, LogDataHelper logDataHelper)
        {
            _logger = logger;
            _logDataHelper = logDataHelper;
        }

        public void OnGet()
        {
            _logger.LogInformation("Executing OnGet. Calling LogDataHelper");

            _logDataHelper
                .LogSimpleMessages()
                .LogMessagesWithValues()
                .LogMessagesWithSerilog()
                .LogException()
                ;
        }
    }
}
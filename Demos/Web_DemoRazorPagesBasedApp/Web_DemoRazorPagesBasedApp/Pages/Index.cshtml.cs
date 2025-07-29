using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web_DemoRazorPagesBasedApp.Services;

namespace Web_DemoRazorPagesBasedApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMessageService _messageService;

        public IndexModel(ILogger<IndexModel> logger, IMessageService messageService)
        {
            _logger = logger;
            _messageService = messageService;
        }

        public void OnGet()
        {
            //_logger.LogCritical("Index page accessed at {Time}", DateTime.Now);
            Console.WriteLine($"OnGet() invoked at: {DateTime.Now}");
            _logger.LogInformation(_messageService.SendMessage("Hi There!"));
            ViewData["Message"] = _messageService.SendMessage("Hi There!");
        }

        public IActionResult OnPost()
        {
            // This method is called when the form on the Index page is submitted.
            // You can handle form submission logic here.
            _logger.LogInformation("Form submitted at {Time}", DateTime.Now);
            // You can also redirect or return a view as needed.
            return RedirectToPage("Privacy");

        }
    }
}

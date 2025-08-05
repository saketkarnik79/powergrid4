using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace API_DemoWebAPIBasics.Filters
{
    public class LogActionFilter : IActionFilter,IResourceFilter
    {
        private readonly ILogger<LogActionFilter> _logger;

        public LogActionFilter(ILogger<LogActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"Action {context.ActionDescriptor.DisplayName} executed at {DateTime.UtcNow}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"Action {context.ActionDescriptor.DisplayName} executing at {DateTime.UtcNow}");

        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            _logger.LogInformation($"Action {context.ActionDescriptor.DisplayName} executed at {DateTime.UtcNow}");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _logger.LogInformation($"Action {context.ActionDescriptor.DisplayName} executing at {DateTime.UtcNow}");
        }
    }
}

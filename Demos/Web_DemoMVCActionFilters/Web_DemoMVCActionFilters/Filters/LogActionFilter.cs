using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Web_DemoMVCActionFilters.Filters
{
    public class LogActionFilter : IActionFilter//, IResultFilter
    {
        private readonly ILogger<LogActionFilter> _logger;
        
        public LogActionFilter(ILogger<LogActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)//Post filter
        {
            _logger.LogInformation($"Action executed: {context.Controller.GetType().Name}/{context.ActionDescriptor.DisplayName}");
        }


        public void OnActionExecuting(ActionExecutingContext context)//Pre filter
        {
            _logger.LogInformation($"Action executing: {context.Controller.GetType().Name}/{context.ActionDescriptor.DisplayName}");
        }

        //public void OnResultExecuted(ResultExecutedContext context)
        //{
        //    throw new NotImplementedException();
        //}

        //public void OnResultExecuting(ResultExecutingContext context)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

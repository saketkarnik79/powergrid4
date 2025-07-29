using Microsoft.AspNetCore.Http;

namespace Web_DemoRazorPagesBasedApp.Middlewares
{
    public class CustomHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //Pre-processing logic before the request is handled
            context.Response.OnStarting(() =>
            {
                Console.WriteLine($"Custom middleware invoked at: {DateTime.Now}");
                Console.WriteLine("Adding custom header middleware executing...");
                context.Response.Headers.Add("X-Custom-Header", "My Custom Header Value");
                return Task.CompletedTask;
            });

            await _next(context);

            //Post-processing logic after the request is handled
            // You can add more headers or modify the response here if needed
            // For example, you could log the response status code
            Console.WriteLine($"Response Status Code: {context.Response.StatusCode}");
        }
    }
}

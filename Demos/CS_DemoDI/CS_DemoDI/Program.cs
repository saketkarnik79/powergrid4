using ServicesLib.Services.Contracts;
using ServicesLib.Services.ServiceImplementations;
using Microsoft.Extensions.DependencyInjection;
using ServicesLib;
using System.Diagnostics;

namespace CS_DemoDI
{
    /// <summary>
    /// Entry point for the CS_DemoDI console application.
    /// Demonstrates dependency injection with a message service.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Configures dependency injection, creates a processor, and sends a message.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            // Create a new service collection for dependency injection
            var serviceCollection = new ServiceCollection();

            // Register IMessageService with a specific implementation (ConsoleMessageServiceV1)
            serviceCollection.AddScoped<IMessageService, ConsoleMessageServiceV1>();

            // Build the service provider and retrieve the IMessageService instance
            var messageService = serviceCollection.BuildServiceProvider().GetService<IMessageService>();

            // Create a processor and use it to process a message
            Processor processor = new Processor(messageService);
            processor.Process("Hello, Dependency Injection!");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

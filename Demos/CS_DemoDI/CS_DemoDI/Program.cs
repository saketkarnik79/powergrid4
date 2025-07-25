using ServicesLib.Services.Contracts;
using ServicesLib.Services.ServiceImplementations;
using Microsoft.Extensions.DependencyInjection;
using ServicesLib;
using System.Diagnostics;

namespace CS_DemoDI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            // Registering services
            serviceCollection.AddScoped<IMessageService, ConsoleMessageServiceV1>();
            var messageService = serviceCollection.BuildServiceProvider().GetService<IMessageService>();
            Processor processor = new Processor(messageService);
            processor.Process("Hello, Dependency Injection!");
            // Using the service
            //if (messageService != null)
            //{
            //    messageService?.SendMessage("Hello, Dependency Injection!");
            //}
            //else
            //{
            //    Console.WriteLine("Message service not found.");
            //}

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

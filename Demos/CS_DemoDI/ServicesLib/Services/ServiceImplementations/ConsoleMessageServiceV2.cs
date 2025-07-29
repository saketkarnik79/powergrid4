using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesLib.Services.Contracts;

namespace ServicesLib.Services.ServiceImplementations
{
    /// <summary>
    /// An alternative implementation of IMessageService that writes messages to the console.
    /// </summary>
    public class ConsoleMessageServiceV2 : IMessageService
    {
        /// <summary>
        /// Sends a message by writing it to the console, indicating this is V2.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public void SendMessage(string message)
        {
            Console.WriteLine($"Sending message: {message} from ConsoleMessageServiceV2");
        }
    }
}

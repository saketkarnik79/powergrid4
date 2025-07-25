using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicesLib.Services.Contracts;

namespace ServicesLib.Services.ServiceImplementations
{
    public class ConsoleMessageServiceV1 : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Sending message: {message} from ConsoleMessageServiceV1");

        }
    }
}

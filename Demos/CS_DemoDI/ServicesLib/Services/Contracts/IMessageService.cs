using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLib.Services.Contracts
{
    /// <summary>
    /// Defines a contract for sending messages.
    /// Implementations of this interface provide specific message delivery mechanisms.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Sends a message using the implementation's delivery mechanism.
        /// </summary>
        /// <param name="message">The message to send.</param>
        void SendMessage(string message);
    }
}

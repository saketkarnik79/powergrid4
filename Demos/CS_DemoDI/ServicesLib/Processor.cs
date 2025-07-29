using ServicesLib.Services.Contracts;

namespace ServicesLib
{
    // The Processor class is responsible for handling message processing using an IMessageService implementation.
    public class Processor
    {
        // Holds a reference to the injected IMessageService.
        private readonly IMessageService _messageService;

        // Constructor that accepts an IMessageService dependency via dependency injection.
        public Processor(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // Processes the given message by sending it through the IMessageService.
        public void Process(string msg)
        {
            _messageService.SendMessage(msg);
        }
    }
}

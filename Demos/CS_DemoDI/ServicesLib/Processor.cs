using ServicesLib.Services.Contracts;

namespace ServicesLib
{
    public class Processor
    {
        private readonly IMessageService _messageService;
        
        public Processor(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void Process(string msg)
        {
            _messageService.SendMessage(msg);
        }
    }
}

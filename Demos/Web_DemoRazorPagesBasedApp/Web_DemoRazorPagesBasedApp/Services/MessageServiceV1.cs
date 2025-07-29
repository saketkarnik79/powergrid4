namespace Web_DemoRazorPagesBasedApp.Services
{
    public class MessageServiceV1 : IMessageService
    {
        public string SendMessage(string message)
        {
            return $"Message from MessageServiceV1: {message}";
        }
    }
}

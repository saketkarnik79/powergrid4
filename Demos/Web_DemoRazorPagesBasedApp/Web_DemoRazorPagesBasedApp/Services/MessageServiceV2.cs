namespace Web_DemoRazorPagesBasedApp.Services
{
    public class MessageServiceV2: IMessageService
    {
        public string SendMessage(string message)
        {
            return $"Message from MessageServiceV2: {message}";
        }
    }
}

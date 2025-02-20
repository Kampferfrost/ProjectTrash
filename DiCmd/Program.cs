namespace DiCmd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotificationService notificationService = new NotificationService(new EmailService());
            notificationService.Notify();
        }
    }

    internal class NotificationService
    {
        private readonly IMessageService _messageService;

        public NotificationService(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public void Notify()
        {

            _messageService.SendMessage("сообщение");
        }

        public void NotifyAll()
        {
            _messageService.SendMessage("сообщение");

        }
    }

    internal class EmailService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("Email - " + message);
        }
    }

    internal class TelegramService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("Telegram - " + message);
        }
    }

    internal class SkoofService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("Skoof - " + message);
        }
    }

    public interface IMessageService
    {
        void SendMessage(string message);
    }
}

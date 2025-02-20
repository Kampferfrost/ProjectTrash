namespace DiCmd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NotificationService notificationService = new NotificationService();
            notificationService.Notify();
        }
    }

    internal class NotificationService
    {
        public void Notify()
        {
            var emailService = new EmailService();
            emailService.SendMessage("сообщение");
        }

        public void NotifyAll()
        {
            var emailService = new EmailService();
            emailService.SendMessage("сообщение");
        }
    }

    internal class EmailService 
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("Email - " + message);
        }
    }

    internal class TelegramService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("Telegram - " + message);
        }
    }

    internal class SkoofService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("Skoof - " + message);
        }
    }
}

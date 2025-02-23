using Microsoft.Extensions.DependencyInjection;

namespace DiCmd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IMessageService, EmailService>();
            services.AddTransient<NotificationService>();
            services.AddTransient<ILogger, ConsoleLogger>();
            services.AddTransient<IDataBase, PostrgesDatabase>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            var notificationService = serviceProvider.GetService<NotificationService>();

            notificationService?.Notify();
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
        private readonly ILogger _logger;
        private readonly IDataBase _database;

        public EmailService(ILogger logger, IDataBase database)
        {
            _logger = logger;
            _database = database;
        }

        public void SendMessage(string message)
        {
            Console.WriteLine("Email - " + message);
            _database.Save();
            _logger.Log("Сообщение успешно отправленно");
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

     public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class PostrgesDatabase : IDataBase
    {
        private readonly ILogger _logger;

        public PostrgesDatabase(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            Console.WriteLine("Данные сохранены");
            _logger.Log("Операция прошла успешно");
        }
    }


}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebDi1.Controllers
{
    public class LearnController : Controller
    {
        private readonly IMessageService _messageService;

        public LearnController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var message = _messageService.SendMessage("Сообщение");
            return Ok(message);
        }



        public IActionResult Index()
        {
            return View();
        }
    }

    public interface IMessageService
    {
        string SendMessage(string message);
    }

    internal class EmailService : IMessageService
    {
        

        public string SendMessage(string message)
        {
            return message;
        }
    }


}

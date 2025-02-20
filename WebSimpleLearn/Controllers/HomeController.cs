using EFCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebSimpleLearn.Models;

namespace WebSimpleLearn.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContextWet applicationContextWet;

        public HomeController(ILogger<HomeController> logger, ApplicationContextWet applicationContextWet)
        {
            _logger = logger;
            this.applicationContextWet = applicationContextWet;
        }

        public List<User> Users { get; set; } = [];

        public IActionResult Index()
        {
            //User hikita = new User() { Name = "Hikita", Age = 42 };
            //User Slam = new User() { Name = "Slam", Age = 42 };

            //applicationContextWet.Users.Add(hikita);
            //applicationContextWet.Users.Add(Slam);
            //applicationContextWet.SaveChanges();

            Users = applicationContextWet.Users.ToList();
            return View(Users);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

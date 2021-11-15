using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TableTendersMVCService.Models;
using System.Diagnostics;
using System.Linq;

namespace TableTendersMVCService.Controllers
{
    public class HomeController : Controller
    {

        TenderContext db;
        public HomeController(TenderContext context, ILogger<HomeController> logger)
        {
            db = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View(db.Tenders.ToList());
        }

        private readonly ILogger<HomeController> _logger;

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

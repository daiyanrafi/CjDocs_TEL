using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using office.Data;
using office.Models;
using System.Diagnostics;

namespace office.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;

        }

        public IActionResult Index()
        {
            var objDocList = _db.Docs.ToList();
            // Save
            var str = JsonConvert.SerializeObject(objDocList);
            HttpContext.Session.SetString("_Menu", str);
            return View();
        }
        public ActionResult RenderMenu()
        {

            return PartialView("~/Shared/_MenuBar.cshtml");
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
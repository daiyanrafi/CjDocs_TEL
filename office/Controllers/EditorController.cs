using Microsoft.AspNetCore.Mvc;

namespace office.Controllers
{
    public class EditorController : Controller
    {

        static List<string> Posts = new List<string>();
        public IActionResult Index()
        {
            return View("Index", Posts);
        }

        public IActionResult EditorPage()
        {
            return View();
        }

        [HttpPost]

        public IActionResult EditorPage(string content)
        {
            Posts.Add(content);
            return RedirectToAction("Index");
        }
    }
}

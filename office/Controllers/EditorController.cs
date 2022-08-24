using Microsoft.AspNetCore.Mvc;
using office.Models;
using System.Linq;

namespace office.Controllers
{
    public class EditorController : Controller
    {
        //save in browser
        static List<BlogBody> Posts = new List<BlogBody>();
        public IActionResult Index()
        {
            return View("Index", Posts);
        }

        public IActionResult EditorPage(Guid id)
        {
            if(id != Guid.Empty)
            {
                BlogBody existingEntry = Posts.FirstOrDefault(x => x.Id == id);

                return View(model: existingEntry);
            }
            return View();
        }

        [HttpPost]

        public IActionResult EditorPage(BlogBody entry)
        {

            if(entry.Id == Guid.Empty)
            {

                //New Article

                BlogBody newEntry = new BlogBody();
                newEntry.Content = entry.Content;
                newEntry.Id = Guid.NewGuid();
                Posts.Add(newEntry);
            }
            else
            {
                //Existing article

                BlogBody existingEntry = Posts.FirstOrDefault(x=> x.Id == entry.Id);
                existingEntry.Content = entry.Content;

            }


            return RedirectToAction("Index");
        }
    }
}

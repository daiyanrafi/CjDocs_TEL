using Microsoft.AspNetCore.Mvc;
using office.Data;
using office.Models;
using System.Linq;

namespace office.Controllers;

public class DocController : Controller
{
    private readonly ApplicationDbContext _db;
    public DocController(ApplicationDbContext db)
    {
        _db = db;
    }

   
    public IActionResult Index ()
    {
        IEnumerable<Doc> objDocList = _db.Docs;
        return View(objDocList);
    }
    //create section

    //GET
    public IActionResult Create()
    {
      
        return View();
    }

    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Doc obj)
    {
        //{
        //    //if (obj != obj.Empty)
        //    //{
        //        BlogBody existingEntry = _db.Docs.FirstOrDefault(x => x.Id == id);

        //        return View(model: existingEntry);
        //    //}

        //}

        if (ModelState.IsValid)
        {
            _db.Docs.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Docs created successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }

    //Edit section

    //GET
    public IActionResult Edit(int? id)
    {
        if(id==null || id == 0)
        {
            return NotFound();
        }
        var DocFromDb= _db.Docs.Find(id);
        //var DocFromFirst = _db.Docs.FirstOrDefault(x => x.Id==id);
        //var DocFromSingle = _db.Docs.SingleOrDefault(x => x.Id == id);

        if (DocFromDb==null)
        {
            return NotFound();
        }

        return View(DocFromDb);
    }

    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Doc obj)
    {

        //Two tab can not be same


        //if (obj.Name == obj.Section.ToString())
        //{
        //    ModelState.AddModelError("Name", "The Name & Section can not be same.");
        //}


        if (ModelState.IsValid)
        {
            _db.Docs.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Docs edited successfully";
            return RedirectToAction("Index");
        }
        return View(obj);
    }


    //Delete Section

    //GET
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var DocFromDb = _db.Docs.Find(id);
        //var DocFromFirst = _db.Docs.FirstOrDefault(x => x.Id==id);
        //var DocFromSingle = _db.Docs.SingleOrDefault(x => x.Id == id);

        if (DocFromDb == null)
        {
            return NotFound();
        }

        return View(DocFromDb);
    }

    //Post
    [HttpPost,ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _db.Docs.Find(id);
        if (obj == null)
        {
            return NotFound();
        }

        _db.Docs.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Docs deleted successfully";
        return RedirectToAction("Index");



    }

    //Details

    //GET
    //GET
    public IActionResult Details(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var DocFromDb = _db.Docs.Find(id);
        //var DocFromFirst = _db.Docs.FirstOrDefault(x => x.Id==id);
        //var DocFromSingle = _db.Docs.SingleOrDefault(x => x.Id == id);

        if (DocFromDb == null)
        {
            return NotFound();
        }

        return View(DocFromDb);
    }



}

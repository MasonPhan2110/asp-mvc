using Bulky.DataAccess.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bulky.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }

    // GET: /<controller>/
    public IActionResult Index()
    {
        var objCategoryList = _db.Categories.ToList();
        return View(objCategoryList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category obj)
    {
        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category created Successfully";
            return RedirectToAction("Index");
        }

        return View();
    }

    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0) return NotFound();

        var categoryFromDB = _db.Categories.Find(id);
        // Category? categoryFromDB1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
        // Category? categoryFromDB2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
        if (categoryFromDB == null) return NotFound();
        return View(categoryFromDB);
    }

    [HttpPost]
    public IActionResult Edit(Category obj)
    {
        if (ModelState.IsValid)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category updated Successfully";
            return RedirectToAction("Index");
        }

        return View();
    }

    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0) return NotFound();

        var categoryFromDB = _db.Categories.Find(id);
        // Category? categoryFromDB1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
        // Category? categoryFromDB2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
        if (categoryFromDB == null) return NotFound();
        return View(categoryFromDB);
    }

    [HttpPost]
    [ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _db.Categories.Find(id);
        if (obj == null) return NotFound();

        _db.Categories.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Category deleted Successfully";
        return RedirectToAction("Index");
    }
}
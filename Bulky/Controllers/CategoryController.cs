using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bulky.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bulky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View();
        }
    }
}


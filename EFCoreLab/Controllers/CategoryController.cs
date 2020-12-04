using Lab.DataAccess.Data;
using Lab.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreLab.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Upsert(int? id)
        {
            Category category = new Category();

            if (id == null)
            {
                //for create, we dont need any id
                return View(category);
            }

            category = _context.Categories.FirstOrDefault(x => x.Category_Id == id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if(ModelState.IsValid)
            {
                if(category.Category_Id == 0)
                {
                    //this is create
                    _context.Categories.Add(category);
                }
                else
                {
                    //this is update
                    _context.Categories.Update(category);
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }
    }
}

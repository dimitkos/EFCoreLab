using Lab.DataAccess.Data;
using Lab.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
            if (ModelState.IsValid)
            {
                if (category.Category_Id == 0)
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

        public IActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Category_Id == id);
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple2()
        {
            List<Category> categoryList = new List<Category>();
            for (int i = 1; i <= 2; i++)
            {
                categoryList.Add(new Category { Name = Guid.NewGuid().ToString() });
            }
            _context.AddRange(categoryList);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple5()
        {
            List<Category> categoryList = new List<Category>();

            for (int i = 1; i <= 5; i++)
            {
                categoryList.Add(new Category { Name = Guid.NewGuid().ToString() });
            }
            _context.AddRange(categoryList);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            //take the last 2 categories
            IEnumerable<Category> categoryList = _context.Categories
                .OrderByDescending(x => x.Category_Id)
                .Take(2)
                .ToList();

            _context.RemoveRange(categoryList);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple5()
        {
            //take the last 2 categories
            IEnumerable<Category> categoryList = _context.Categories
                .OrderByDescending(x => x.Category_Id)
                .Take(5)
                .ToList();

            _context.RemoveRange(categoryList);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}

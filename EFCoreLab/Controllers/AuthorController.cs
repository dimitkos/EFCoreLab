using Lab.DataAccess.Data;
using Lab.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreLab.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Author> authors = _context.Authors.ToList();
            return View(authors);
        }

        public IActionResult Upsert(int? id)
        {

            Author author = new Author();

            if (id == null)
            {
                //for create, we dont need any id
                return View(author);
            }

            author = _context.Authors.FirstOrDefault(x => x.Author_Id == id);

            if (author == null)
                return NotFound();

            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Author author)
        {
            if (ModelState.IsValid)
            {
                if (author.Author_Id == 0)
                {
                    //this is create
                    _context.Authors.Add(author);
                }
                else
                {
                    //this is update
                    _context.Authors.Update(author);
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(author);
        }

        public IActionResult Delete(int id)
        {
            var category = _context.Authors.FirstOrDefault(x => x.Author_Id == id);
            _context.Authors.Remove(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}

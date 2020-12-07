using Lab.DataAccess.Data;
using Lab.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreLab.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublisherController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Publisher> publishers = _context.Publishers.ToList();
            return View(publishers);
        }

        public IActionResult Upsert(int? id)
        {

            Publisher publisher = new Publisher();

            if (id == null)
            {
                //for create, we dont need any id
                return View(publisher);
            }

            publisher = _context.Publishers.FirstOrDefault(x => x.Publisher_Id == id);

            if (publisher == null)
                return NotFound();

            return View(publisher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                if (publisher.Publisher_Id == 0)
                {
                    //this is create
                    _context.Publishers.Add(publisher);
                }
                else
                {
                    //this is update
                    _context.Publishers.Update(publisher);
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(publisher);
        }

        public IActionResult Delete(int id)
        {
            var category = _context.Publishers.FirstOrDefault(x => x.Publisher_Id == id);
            _context.Publishers.Remove(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}

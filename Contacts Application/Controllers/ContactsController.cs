using Contacts_Application.Data;
using Contacts_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contacts_Application.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ContactsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int? pageNumber, string? childname = null)
        {
            int pageSize = 5;
            if (string.IsNullOrEmpty(childname))
            {
                return View(PaginatedList<Contacts>.Create(_db.Contacts.ToList(), pageNumber ?? 1, pageSize));
            }
            else
            {
                var obj = _db.Contacts.Where(e => e.Name.Contains(childname)).ToList();
                if (obj == null)
                {
                    return View("Index");
                }
                return View("Index", PaginatedList<Contacts>.Create(obj, pageNumber ?? 1, pageSize));
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Detail(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Contacts.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        public IActionResult Create(Contacts obj)
        {
            if (ModelState.IsValid)
            {
                _db.Contacts.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Contacts.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Patch
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Contacts obj)
        {
            if (ModelState.IsValid)
            {
                _db.Contacts.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult DeleteView(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var contactsFromDb = _db.Contacts.Find(id);
            if (contactsFromDb == null)
            {
                return NotFound();
            }
            return View(contactsFromDb);
        }

        //Delete
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var contactsFromDb = _db.Contacts.Find(id);
            if (contactsFromDb == null)
            {
                return NotFound();
            }
            _db.Contacts.Remove(contactsFromDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
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
        public IActionResult Index()
        {
            IEnumerable<Contacts> objContactsList = _db.Contacts;
            return View(objContactsList);
        }


        // GET
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Detail(int?id)
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contacts obj) {
            if (ModelState.IsValid)
            {    
                _db.Contacts.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int?id)
        {
            if (id==null || id==0)
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

        public IActionResult Delete(int? id)
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
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(Contacts obj)
        {

                _db.Contacts.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }


    }
}

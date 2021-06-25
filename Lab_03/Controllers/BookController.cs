using Lab_03.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab_03.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            BookManagerContext db = new BookManagerContext();
            List<Book> list = db.Books.ToList();
            return View(list);
        
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManagerContext db = new BookManagerContext();
            Book book = db.Books.SingleOrDefault(p => p.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBook(Book book)
        {
            if (ModelState.IsValid)
            {
                BookManagerContext db = new BookManagerContext();
                Book model = new Book();
                model.Author = book.Author;
                model.Title = book.Title;
                model.ImageCover = book.ImageCover;
                model.Price = book.Price;
                model.Description = book.Description;
                db.Books.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index", "Book");
            }
            return View();
        }
        public ActionResult EditBook(int id)
        {
            BookManagerContext db = new BookManagerContext();
            Book book = db.Books.FirstOrDefault(p => p.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(Book book)
        {
            BookManagerContext db = new BookManagerContext();
            Book dbUpdate = db.Books.FirstOrDefault(p => p.Id == book.Id);
            if (dbUpdate != null)
            {

                db.Books.AddOrUpdate(book); //Add or Update Book b
                db.SaveChanges();
                return RedirectToAction("Index", "Book");
            }
            return View(book);
        }
        public ActionResult Delete(int id)
        {
            BookManagerContext db = new BookManagerContext();
            Book book = db.Books.FirstOrDefault(p => p.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        public ActionResult DeleteBook(int id)
        {
            BookManagerContext db = new BookManagerContext();
            Book dbDelete = db.Books.FirstOrDefault(p => p.Id == id);
            if (dbDelete != null)
            {
                db.Books.Remove(dbDelete); //Add or Update Book b
                db.SaveChanges();
                return RedirectToAction("Index", "Book");
            }
            return View(dbDelete);
        }
    }
}
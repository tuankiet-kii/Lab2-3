using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public string HelloTeacher(string university)
        {
            return "hello Kiet Ne - University" + university;
        }
        public ActionResult ListBook()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML & CSS3 The complete Manual", "Author Name Book 1", "~/Content/Images/book2cover.jpg"));
            books.Add(new Book(2, "HTML & CSS Responsive web Design cookbook", "Author Name Book 2", "~/Content/Images/book2cover.png"));
            books.Add(new Book(3, "Professional ASP NET MVC5 ", "Author Name Book 3", "~/Content/Images/book3cover.png"));
            return View(books);
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1,"HTML5 & CSS3 The complete mannuaal","Author Name Book 1","/Content/Images/book1cover.jpg"));
            books.Add(new Book(2,"HTML5 & CSS Responsive web Design cookbook "," Author Name Book 1", "/Content/Images/book2cover.png"));
            books.Add(new Book(3,"Professional"," ASP.NET MVC5 ", "/Content/Images/book3cover.png"));
            return View(books);
        }
        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]


        public ActionResult EditBook(int id, string Title, string Author,string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete mannuaal", "Author Name Book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook ", " Author Name Book 1", "/Content/Images/book2cover.png"));
            books.Add(new Book(3, "Professional", " ASP.NET MVC5 ", "/Content/Images/book3cover.png"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {

                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View("ListBookModel");
        }
        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id, Title, Author, Image_cover")] Book bookData)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The complete mannuaal", "Author Name Book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook ", " Author Name Book 1", "/Content/Images/book2cover.png"));
            books.Add(new Book(3, "Professional", " ASP.NET MVC5 ", "/Content/Images/book3cover.png"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(bookData);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Error save data");
            }
            return View("ListBookModel", books);
        }
    }
}
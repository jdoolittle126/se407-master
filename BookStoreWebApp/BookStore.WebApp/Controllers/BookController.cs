using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Library;
using BookStore.Library.Models;
using BookStore.WebApp.Helpers;

namespace BookStore.WebApp.Controllers
{
    public class BookController : Controller
    {

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View(BookStoreFunctions.GetBookById(id, true));
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = DropDownFormatter.FormatGenres();
            ViewBag.AuthorId = DropDownFormatter.FormatAuthors();
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                BookStoreFunctions.AddBook(book);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.GenreId = DropDownFormatter.FormatGenres();
            ViewBag.AuthorId = DropDownFormatter.FormatAuthors();
            return View(BookStoreFunctions.GetBookById(id, true));
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            try
            {
                BookStoreFunctions.EditBook(book);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(BookStoreFunctions.GetBookById(id));
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Book book)
        {
            try
            {
                BookStoreFunctions.DeleteBook(book);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
    }
}

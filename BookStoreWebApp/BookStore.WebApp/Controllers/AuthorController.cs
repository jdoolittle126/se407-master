using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Library;
using BookStore.Library.Models;

namespace BookStore.WebApp.Controllers
{
    public class AuthorController : Controller
    {
        // GET: AuthorController
        public ActionResult Index()
        {
            return View(AuthorFunctions.GetAllAuthors());
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            return View(AuthorFunctions.GetAuthorById(id));
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            try
            {
                AuthorFunctions.AddAuthor(author);
                return RedirectToAction("Index", "Author");
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(AuthorFunctions.GetAuthorById(id));
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author author)
        {
            try
            {
                AuthorFunctions.EditAuthor(author);
                return RedirectToAction("Index", "Author");
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(AuthorFunctions.GetAuthorById(id));
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Author author)
        {
            try
            {
                AuthorFunctions.DeleteAuthor(author);
                return RedirectToAction("Index", "Author");
            }
            catch
            {
                return View();
            }
        }
    }
}

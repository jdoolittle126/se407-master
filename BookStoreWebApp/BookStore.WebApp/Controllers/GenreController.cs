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
    public class GenreController : Controller
    {
        // GET: GenreController
        public ActionResult Index()
        {
            return View(GenreFunctions.GetAllGenres());
        }

        // GET: GenreController/Details/5
        public ActionResult Details(int id)
        {
            return View(GenreFunctions.GetGenreById(id));
        }

        // GET: GenreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            try
            {
                GenreFunctions.AddGenre(genre);
                return RedirectToAction("Index", "Genre");
            }
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GenreFunctions.GetGenreById(id));
        }

        // POST: GenreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genre)
        {
            try
            {
                GenreFunctions.EditGenre(genre);
                return RedirectToAction("Index", "Genre");
            }
            catch
            {
                return View();
            }
        }

        // GET: GenreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(GenreFunctions.GetGenreById(id));
        }

        // POST: GenreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Genre genre)
        {
            try
            {
                GenreFunctions.DeleteGenre(genre);
                return RedirectToAction("Index", "Genre");
            }
            catch
            {
                return View();
            }
        }
    }
}

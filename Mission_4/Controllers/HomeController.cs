using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission_4.Models;

namespace Mission_4.Controllers
{
    public class HomeController : Controller
    {

        private MoviesContext _movieContext { get; set; }

        public HomeController(MoviesContext movies)
        {
            _movieContext = movies;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult My_Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.Category = _movieContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Movies(Movies_Form form)
        {
            if (ModelState.IsValid)
            {
            _movieContext.Add(form);
            _movieContext.SaveChanges();
            return View("Confirmation", form);
            }
            else
            {
                ViewBag.Category = _movieContext.Categories.ToList();

                return View(form);
            }
        }

        [HttpGet]
        public IActionResult Library()
        {
            var movies = _movieContext.forms
                .Include(x => x.Category)
                .ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieID)
        {
            ViewBag.Category = _movieContext.Categories.ToList();
            var movie = _movieContext.forms.Single(x => x.MovieID == movieID);
            return View("Movies", movie);
        }

        [HttpPost]
        public IActionResult Edit(Movies_Form form)
        {
            _movieContext.Update(form);
            _movieContext.SaveChanges();
            return RedirectToAction("Library");
        }

        [HttpGet]
        public IActionResult Delete(int movieID)
        {
            var movie = _movieContext.forms.Single(x => x.MovieID == movieID);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Movies_Form form)
        {
            _movieContext.forms.Remove(form);
            _movieContext.SaveChanges();
            return RedirectToAction("Library");
        }
    }
}

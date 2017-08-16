using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //
        // GET: /Movies/Random
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovie))
                return View("List");
            return View("ReadOnlyList");


        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.GreneType).SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return Content("We don't have any movie.");
            }
            else
            {
                return View(movie);
            }
        }

        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult New()
        {
            var greneType = _context.GreneTypes.ToList();
            var viewModel = new MovieFormViewModel
            {
                GreneTypes = greneType
            };
            return View("MovieForm",viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    GreneTypes = _context.GreneTypes.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id==0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleseDate = movie.ReleseDate;
                movieInDb.GreneTypeId = movie.GreneTypeId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }



        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            var viewModel = new MovieFormViewModel(movie)
            {
                GreneTypes = _context.GreneTypes.ToList()
            };

            return View("MovieForm",viewModel);

        }
    }
}
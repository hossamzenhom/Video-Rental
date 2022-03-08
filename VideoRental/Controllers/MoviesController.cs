using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRental.Models;
using VideoRental.Models.ViewModels;

namespace VideoRental.Controllers
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

        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            if (User.IsInRole("CanManageMovies"))
            {
                return View("List", movies);
            }


           return View("ReadOnlyList", movies);
        }

        [Authorize(Roles = "CanManageMovies")]
        public ActionResult MovieForm()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new ViewModelMoviesForm()
            {
                Movie = new Movie(),
                Genres=genres

            };


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ViewModelMoviesForm()
                {
                    Movie = new Movie(),
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);

            }
            else
            {
                var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                if (movieInDb == null)
                {
                    return HttpNotFound();
                }
                movieInDb.Name = movie.Name;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.Genre = movie.Genre;
                movieInDb.ReleaseDate=movie.ReleaseDate;
                movieInDb.NumberInStock=movie.NumberInStock;

            }


            _context.SaveChanges();
            
            return RedirectToAction("Index","Movies");
        }


        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m=>m.Id==id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ViewModelMoviesForm()
            {
                Genres = _context.Genres.ToList(),
                Movie = movie
            };
            
            return View("MovieForm", viewModel);
        }


    }
}


















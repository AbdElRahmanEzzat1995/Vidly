using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        [Route("Movies/Index")]
        public ViewResult Index()
        {
            //var Movies = _context.Movies.Include(c => c.GenreType);
            if (User.IsInRole("AdminModifyCustomersMovies"))
                return View("Index"); 
            return View("ReadOnlyList");
        }

        [Authorize(Roles = "AdminModifyCustomersMovies")]
        [Route("Movies/Edit/{Id?}")]
        public ActionResult Edit(int id)
        {
            MovieGenreView MGV = new MovieGenreView()
            {
                Movie = _context.Movies.SingleOrDefault(m => m.Id == id),
                GenreList = _context.GenreTypes
            };
            if (MGV.Movie == null)
                return HttpNotFound();

            return View("AddMovie",MGV);
        }


        [Authorize(Roles = "AdminModifyCustomersMovies")]
        public ActionResult AddMovie()
        {
            MovieGenreView MGV = new MovieGenreView()
            {
                //Movie = new Movie(),
                GenreList = _context.GenreTypes
            };
            return View(MGV);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MovieGenreView G)
        {
            G.GenreList = _context.GenreTypes.ToList();
            if (!ModelState.IsValid)
            {
                return View("AddMovie", G);
            }
            if (G.Movie.Id == 0)
                _context.Movies.Add(G.Movie);
            else
            {
                var MovInDb = _context.Movies.SingleOrDefault(c => c.Id == G.Movie.Id);
                MovInDb.Id = G.Movie.Id;
                MovInDb.Name = G.Movie.Name;
                //MovInDb.DateAdded = G.Movie.DateAdded;
                MovInDb.ReleaseDate = G.Movie.ReleaseDate;
                MovInDb.NumberInStock = G.Movie.NumberInStock;
                MovInDb.GenreTypeId = G.Movie.GenreTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

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
            var R = _context.Movies.ToList();
            return View(R);
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            var mvs = _context.Movies.ToList();
            Movie m = mvs.ElementAt(id - 1);
            if (mvs.Count == 0)
                return HttpNotFound();

            return View(m);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        [Route("Customers/Index")]
        public ActionResult Index()
        {
            var R = _context.Customers.Include(c=>c.MembershipType);
            return View(R);
        }


        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            var cus = _context.Customers.Include(c => c.MembershipType);
            List<Customer> cl=cus.ToList();
            Customer customer=cl.ElementAt(id - 1);
            if (cl.Count == 0)
                return HttpNotFound();

            return View(customer);
        }
        
    }
}
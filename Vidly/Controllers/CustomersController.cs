using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        // GET: Customers
        [Route("Customers/Index")]
        public ActionResult Index()
        {
            var R = GetCustomers();
            return View(R);
        }


        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            //RandomMovieCustomerModel R = new RandomMovieCustomerModel();
            //R.Customers = GetCustomers1();
            //if (R.Customers == null)
            //    return HttpNotFound();
            //return View(R);
            var customer = GetCustomers().SingleOrDefault(c => c.id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { id = 1, Name = "John Smith" },
                new Customer { id = 2, Name = "Mary Williams" }
            };
        }

        private List<Customer> GetCustomers1()
        {
            return new List<Customer>
            {
                new Customer { id = 1, Name = "John Smith" },
                new Customer { id = 2, Name = "Mary Williams" }
            };
        }
    }
}
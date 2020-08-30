using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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
            var R = _context.Customers.Include(c => c.MembershipType);
            return View(R);
        }


        [Route("Customers/Details/{Id}")]
        public ActionResult Details(int id)
        {
            var cus = _context.Customers.Include(c => c.MembershipType);
            List<Customer> cl = cus.ToList();
            Customer customer = cl.ElementAt(id - 1);
            if (cl.Count == 0)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult AddCustomer()
        {
            var ML = _context.MembershipTypes;
            CustomerMemberTypeView CMV = new CustomerMemberTypeView()
            {
                //Customer = new Customer(),
                MembershipList = ML
            };
            return View(CMV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerMemberTypeView C)
        {
            if (!ModelState.IsValid)
            {
                C.MembershipList = _context.MembershipTypes;
                return View("AddCustomer", C);
            }
            if (C.Customer.Id == 0)
                _context.Customers.Add(C.Customer);
            else
            {
                var CusInDb = _context.Customers.SingleOrDefault(c => c.Id == C.Customer.Id);
                CusInDb.Name = C.Customer.Name;
                CusInDb.Birthdate = C.Customer.Birthdate;
                CusInDb.MembershipTypeId = C.Customer.MembershipTypeId;
                CusInDb.IsSubscribedToNewsLetter = C.Customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        [Route("Customers/Edit/{Id}")]
        public ActionResult Edit(int id)
        {
            var cus = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (cus == null)
                return HttpNotFound();

            var Model = new CustomerMemberTypeView()
            {
                Customer = cus,
                MembershipList = _context.MembershipTypes.ToList()
            };
            return View("AddCustomer", Model);
        }

    }
}
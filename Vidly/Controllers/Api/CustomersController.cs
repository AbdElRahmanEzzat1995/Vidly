using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context ;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        
        //GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.Include(c=>c.MembershipType).ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }

        //GET /api/customers/id
        public IHttpActionResult GetCustomer(int id)
        {
            var cus=_context.Customers.SingleOrDefault(m => m.Id == id);
            if (cus == null)
                return NotFound();
            else
                return Ok(Mapper.Map<Customer, CustomerDto>(cus));
        }


        //POST /api/customers/id
        [HttpPost]
        public IHttpActionResult AddCustomer(CustomerDto cusDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cus = Mapper.Map<CustomerDto, Customer>(cusDto);
                _context.Customers.Add(cus);
                _context.SaveChanges(); 
                return Created(new Uri(Request.RequestUri+"/"+cus.Id),cusDto);
        }


        //PUT /api/customers/id
        [HttpPut]
        public void EditCustomer(int id,CustomerDto cusDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var cusInDb = _context.Customers.SingleOrDefault(m => m.Id == id);
            if (cusInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<CustomerDto,Customer>(cusDto,cusInDb);
            _context.SaveChanges();
        }

        //DELETE /api/customers/id
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var cusInDb = _context.Customers.SingleOrDefault(m => m.Id == id);
            if (cusInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(cusInDb);
            _context.SaveChanges();
        }

    }
}

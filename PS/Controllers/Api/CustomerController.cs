using PS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PS.Controllers.Api
{
    public class CustomerController : ApiController
    {
        // GET api/<controller>
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.customers.ToList();
        }


        // GET api/<controller>/5
        public Customer GetCustomers(int id)
        {
            var customer = _context.customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpRequestException();
            return customer;
        }
        [HttpPost]
        // POST api/<controller>
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpRequestException();
            _context.customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpRequestException();
            var customerInDb = _context.customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpRequestException();
            customerInDb.Name = customerInDb.Name;

            customerInDb.PhoneNo = customerInDb.PhoneNo;
            customerInDb.Email = customerInDb.Email;
            _context.SaveChanges();

        }

        // DELETE api/<controller>/5
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpRequestException();
            _context.customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}

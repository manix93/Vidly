using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private VidlyDBContext _context;

        public CustomersController()
        {
            _context = new VidlyDBContext();
        }

        //GET /api/customers
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        //GET /api/customers/id
        [HttpGet]
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        //POST /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        //PUT /api/customers/id
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var _customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _customer.Name = customer.Name;
            _customer.Birthdate = customer.Birthdate;
            _customer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            _customer.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
        }

        //DELETE /api/customers/id
        [HttpDelete]
        public void DeleteCustomer(int id, Customer customer)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var _customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(_customer);      
            _context.SaveChanges();
        }
    }
}

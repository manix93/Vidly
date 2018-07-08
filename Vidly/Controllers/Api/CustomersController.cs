using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using Vidly.Models;
using Vidly.ViewModels;

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
        public IEnumerable<CustomerViewModel> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerViewModel>);
        }

        //GET /api/customers/id
        [HttpGet]
        public CustomerViewModel GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer, CustomerViewModel>(customer);
        }

        //POST /api/customers
        [HttpPost]
        public CustomerViewModel CreateCustomer(CustomerViewModel customerVM)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerViewModel, Customer>(customerVM);     
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerVM.Id = customer.Id;

            return customerVM;
        }

        //PUT /api/customers/id
        [HttpPut]
        public void UpdateCustomer(int id, CustomerViewModel customerVM)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var _customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(_customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<CustomerViewModel, Customer>(customerVM, _customer);

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

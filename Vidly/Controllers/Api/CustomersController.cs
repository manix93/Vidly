using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
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
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        }

        //GET /api/customers/id
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerVM)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerVM);     
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerVM.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customerVM.Id), customerVM);
        }

        //PUT /api/customers/id
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerVM)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var _customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(_customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<CustomerDTO, Customer>(customerVM, _customer);

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

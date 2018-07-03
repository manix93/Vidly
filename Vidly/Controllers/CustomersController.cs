using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>()
            {
                new Customer() {Id = 1, Name = "Felipe Massa"},
                new Customer() {Id = 2, Name = "Kimi Raikkonen"},
                new Customer() {Id = 3, Name = "Lionel Messi"}
            };

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customers = new List<Customer>()
            {
                new Customer() {Id = 1, Name = "Felipe Massa"},
                new Customer() {Id = 2, Name = "Kimi Raikkonen"},
                new Customer() {Id = 3, Name = "Lionel Messi"}
            };

            return View(customers[id - 1]);
        }
    }
}
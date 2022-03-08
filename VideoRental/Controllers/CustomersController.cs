using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRental.Models;
using VideoRental.Models.ViewModels;

namespace VideoRental.Controllers
{
    //[Authorize]
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        } 
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        
        
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult CustomerForm()
        {


            var membershipTypes=_context.MembershipTypes.ToList();

            var viewModel = new ViewModelCustomersForms()
            {
                Memberships = membershipTypes,
                Customer = new Customer(),
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new ViewModelCustomersForms()
                {
                    Customer = new Customer(),
                    Memberships = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
                
            }
            else
            {
                var customerInDb=_context.Customers.SingleOrDefault(c=>c.Id == customer.Id);
                if (customerInDb == null)
                {
                    return HttpNotFound();
                }
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer=_context.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }
            
            var viewModel = new ViewModelCustomersForms()
            {
                Customer = customer,
                Memberships = _context.MembershipTypes.ToList()
            };


            return View("CustomerForm",viewModel);
        }
    }
}



















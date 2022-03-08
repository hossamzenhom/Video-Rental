using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using VideoRental.Dtos;
using VideoRental.Models;

namespace VideoRental.Controllers.api
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        //GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {

            return _context.Customers.Include(c=>c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

        }

        
        //GET /api/customers/1
        public CustomerDto GetCustomer(int id)
        {
            var customer= _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        
        //POST /api/customers
        [HttpPost]
        public CustomerDto CreateCusutomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();


            customerDto.Id= customer.Id;


            return customerDto;
        }

        
        //PUT /api/customer/1
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);

            _context.SaveChanges();
        }

        
        //DELETE /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb= _context.Customers.SingleOrDefault(c=>c.Id == id);
            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

        }


    }
}









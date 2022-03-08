﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRental.Dtos;
using VideoRental.Models;

namespace VideoRental.Controllers.api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRental newRental)
        {
            //if (newRentalDto.MovieIds.Count == 0)
            //    return BadRequest("No Movie Ids have been given.");

            var customer=_context.Customers.Single(c=>c.Id==newRental.CustomerId);

            //if (customer == null)
            //    return BadRequest("CustomerId Is Not Valid.");

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            //if (movies.Count != newRentalDto.MovieIds.Count)
            //    return BadRequest("one or more MovieIds are invalid.");




            foreach (var movie in movies)
            {


                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available Now.");


                movie.NumberAvailable--;

                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);

            }

            _context.SaveChanges();

            return Ok(); 

        }
 
    }
}



























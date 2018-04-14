using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
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
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            if (newRentalDto.MoviesIds.Count == 0)
            {
                return BadRequest("No Movie Ids have been given.");
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == newRentalDto.CustomerId);
            
            if (customerInDb == null)
            {
                return BadRequest("Invalid customer ID.");
            }

            var moviesInDb = _context.Movies.Where(m => newRentalDto.MoviesIds.Contains(m.Id)).ToList();

            if (moviesInDb.Count != newRentalDto.MoviesIds.Count)
            {
                return BadRequest("One or more MovieIds are Invalid.");
            }

            foreach (var movie in moviesInDb)
            {
                if (movie.NumberAvaliable == 0)
                {
                    return BadRequest("Movie is not avaliable.");
                }
                movie.NumberAvaliable--;

                Rental rental = new Rental
                {
                    Customer = customerInDb,
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

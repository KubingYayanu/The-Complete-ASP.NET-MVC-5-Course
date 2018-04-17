using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CheckInController : ApiController
    {
        private ApplicationDbContext _context;

        public CheckInController()
        {
            _context = new ApplicationDbContext();
            _context.Database.Log = s => Debug.WriteLine(s);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        /// <summary>
        /// Check In Rentals
        /// </summary>
        /// <param name="checkMoviesInDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult CheckIn(CheckMoviesInDto checkMoviesInDto)
        {
            if (checkMoviesInDto.MoviesIds.Count == 0)
            {
                return BadRequest("No Movie Ids have been given.");
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == checkMoviesInDto.CustomerId);

            if (customerInDb == null)
            {
                return BadRequest("Invalid customer ID.");
            }

            //未歸還的電影; Movies not loading (failure plan)
            //var rentedMoviesByCustomer = (from rented in _context.Rentals
            //                              where rented.CustomerId == checkMoviesInDto.CustomerId
            //                                 && rented.DateReturned == null
            //                              group rented by rented.DateRented into g
            //                              where g.Count() == checkMoviesInDto.MoviesIds.Count()
            //                              && !g.Select(r => r.MovieId).Except(checkMoviesInDto.MoviesIds).Any()
            //                              select g).ToList();

            //if (rentedMoviesByCustomer == null || rentedMoviesByCustomer.Count() == 0)
            //{
            //    return BadRequest("No matched rental.");
            //}

            #region 未歸還的電影

            var rentedMoviesQuery = (from rented in _context.Rentals
                               .Include(r => r.Customer)
                               .Include(r => r.Movie)
                                where rented.CustomerId == checkMoviesInDto.CustomerId
                                && rented.DateReturned == null
                                select rented).ToList();

            var rentedMovies = rentedMoviesQuery.GroupBy(r => r.DateRented)
                .Where(g => g.Count() == checkMoviesInDto.MoviesIds.Count()
                && !g.Select(r => r.MovieId).Except(checkMoviesInDto.MoviesIds).Any())
                .FirstOrDefault();

            if (rentedMovies == null)
            {
                return BadRequest("No matched rental.");
            }

            #endregion

            DateTime now = DateTime.Now;
            foreach (var item in rentedMovies)
            {
                item.DateReturned = now;
                item.Movie.NumberAvaliable++;
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}

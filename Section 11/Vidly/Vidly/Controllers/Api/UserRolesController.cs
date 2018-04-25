using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class UserRolesController : ApiController
    {
        #region Property

        private ApplicationDbContext _context;

        #endregion

        #region Constructor/Destructor

        public UserRolesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        #endregion

        #region Action



        #endregion
    }
}

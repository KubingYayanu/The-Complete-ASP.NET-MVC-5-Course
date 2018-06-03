using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class JwtAudienceController : ApiController
    {
        private ApplicationDbContext _context;

        public JwtAudienceController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public IHttpActionResult AddAudience(string name)
        {
            var clientId = Guid.NewGuid().ToString("N");

            var key = new byte[32];
            RandomNumberGenerator.Create().GetBytes(key);
            var base64Secret = TextEncodings.Base64Url.Encode(key);

            var audience = new JwtAudience
            {
                ClientId = clientId,
                Base64Secret = base64Secret,
                Name = name
            };

            _context.JwtAudiences.Add(audience);
            _context.SaveChanges();

            return Ok();
        }
    }
}

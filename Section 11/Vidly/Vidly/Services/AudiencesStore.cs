using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using Vidly.Models;

namespace Vidly.Services
{
    public class AudiencesStore
    {
        private ApplicationDbContext _context;

        public AudiencesStore()
        {
            _context = new ApplicationDbContext();
        }

        public JwtAudience AddAudience(string name)
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

            return audience;
        }

        public JwtAudience FindAudience(string clientId)
        {
            var audience = _context.JwtAudiences.SingleOrDefault(a => a.ClientId == clientId);

            return audience;
        }
    }
}
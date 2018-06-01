using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System.IdentityModel.Tokens;

namespace Vidly
{
    public partial class Startup
    {
        public void ConfigureJwt(IAppBuilder app)
        {
            string audience = ConfigurationManager.AppSettings["JwtAudience"];
            string issuer = ConfigurationManager.AppSettings["JwtIssuer"];
            string signKey = ConfigurationManager.AppSettings["JwtSignKey"];

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                AllowedAudiences = new[] { audience },
                IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                {
                    new SymmetricKeyIssuerSecurityTokenProvider(issuer, TextEncodings.Base64Url.Decode(signKey))
                },
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudiences = new[] { audience },
                    ValidIssuer = issuer,
                    IssuerSigningKey = new InMemorySymmetricSecurityKey(TextEncodings.Base64Url.Decode(signKey)),
                    IssuerSigningTokens = new SymmetricKeyIssuerSecurityTokenProvider(issuer, signKey).SecurityTokens
                }
            });
        }
    }
}
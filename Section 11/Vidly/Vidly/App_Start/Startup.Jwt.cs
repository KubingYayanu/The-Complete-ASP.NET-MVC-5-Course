using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System.Configuration;
using System.IdentityModel.Tokens;
using Vidly.Providers;

namespace Vidly
{
    public partial class Startup
    {
        /// <summary>
        /// 啟用JWT驗證 Authentication
        /// </summary>
        /// <param name="app"></param>
        public void ConfigureJwt(IAppBuilder app)
        {
            string audience = ConfigurationManager.AppSettings["JwtAudience"];
            string issuer = ConfigurationManager.AppSettings["JwtIssuer"];
            string signKey = ConfigurationManager.AppSettings["JwtSignKey"];

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                //允許來自Query String的Token
                //Provider = new MyOAuthBearerAuthenticationProvider(),
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
                    //IssuerSigningTokens = new SymmetricKeyIssuerSecurityTokenProvider(issuer, signKey).SecurityTokens,
                    ValidateLifetime = true
                }
            });
        }
    }
}
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Vidly.Providers
{
    public class MyOAuthBearerAuthenticationProvider : IOAuthBearerAuthenticationProvider
    {
        public Task RequestToken(OAuthRequestTokenContext context)
        {
            if (context.Request.Method.Equals("GET") && context.Request.Query["token"] != null)
                context.Token = context.Request.Query["token"];

            //為了回傳Task void, 隨便傳入一個值
            return Task.FromResult(0);

            //.net framework 4.6才有
            //return Task.CompletedTask
        }

        public Task ValidateIdentity(OAuthValidateIdentityContext context)
        {
            //為了回傳Task void, 隨便傳入一個值
            return Task.FromResult(0);

            //.net framework 4.6才有
            //return Task.CompletedTask
        }

        public Task ApplyChallenge(OAuthChallengeContext context)
        {
            //為了回傳Task void, 隨便傳入一個值
            return Task.FromResult(0);

            //.net framework 4.6才有
            //return Task.CompletedTask
        }
    }
}
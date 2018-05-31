using Microsoft.Owin.Security.Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Providers
{
    public class CustomFacebookAuthenticationProvider : FacebookAuthenticationProvider
    {
        public override void ApplyRedirect(FacebookApplyRedirectContext context)
        {
            context.Response.Redirect(context.RedirectUri + "&display=popup");
        }
    }
}
using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using ShoeControl.Models;

namespace ShoeControl
{
    public partial class Startup
    {
          
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user    
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider    
            // Configure the sign in cookie    
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                LogoutPath = new PathString("/Account/LogOff"),
                ExpireTimeSpan = TimeSpan.FromMinutes(20.0),
                ReturnUrlParameter = "/Home/Index"
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
              
        }
    }
}
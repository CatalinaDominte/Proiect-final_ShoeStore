using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.Google;
using NLog;
using Owin;
using System;



[assembly: OwinStartupAttribute(typeof(ShoeControl.Startup))]
namespace ShoeControl
{
public partial class Startup
{
        
        public void Configuration(IAppBuilder app)
    {
    ConfigureAuth(app);
    }
}
}


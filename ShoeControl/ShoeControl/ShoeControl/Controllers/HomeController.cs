using NLog;
using ShoeControl.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeControl.Controllers
{
    [Authorize]
  //[SimpleFilter]
  //[CustomErrorHandler]
    public class HomeController : Controller
    {
           
        public ActionResult Index()
        {
            return this.View();
        }
        
           
        [Authorize(Roles = "1")]
        public ActionResult AdminOnlyLink()
        {
            return this.View();
        }
       

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            Logger logger = LogManager.GetCurrentClassLogger();
            logger.Error(filterContext.Exception);
            

            // redirect
            filterContext.Result = this.RedirectToAction("Error", "Home");



            //change the returned view
           // filterContext.Result = new ViewResult
           // {
               // ViewName = "~/Views/Home/Error.cshtml"
          //  };
        }
    }
}    

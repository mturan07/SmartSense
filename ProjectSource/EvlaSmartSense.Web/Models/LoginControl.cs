using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvlaSmartSense.Web.Models
{
   public class LoginControl : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                if (HttpContext.Current.Session["UserId"] != null)
                {
                    base.OnActionExecuting(filterContext);
                }
                else
                {
                    HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri + "Login/UserControl");
                }
            }
            catch (Exception)
            {
                 HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri + "Login/UserControl");
                //HttpContext.Current.Response.Redirect("`~/Login/UserControl");
            }
        }
    }
}
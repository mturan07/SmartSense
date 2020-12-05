using EvlaSmartSense.Web.Data;
using EvlaSmartSense.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvlaSmartSense.Web.Controllers
{
    public class LoginController : Controller
    {
        //[Route("Login/UserControl")]
        public ActionResult UserControl()
        {
            return View();
        }

        [HttpPost]
        //[Route("Login/UserControl")]
        public ActionResult UserControl(string UserName, string Password)
        {
            if (new _Giris().IsLoginSuccess(UserName, Password) != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("UserControl", "Login");
        }

        //[Route("Login/LogOut")]
        public ActionResult LogOut()
        {
            Session.Clear();

            return RedirectToAction("UserControl", "Login");
        }
    }
}
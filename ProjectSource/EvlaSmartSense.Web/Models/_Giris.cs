using EvlaSmartSense.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvlaSmartSense.Web.Models
{
    public class _Giris : Kalitim
    {
        public users IsLoginSuccess(string user, string pass)
        {
            users resultUser = Dbc.users.Where(k => k.ACTIVE == true && k.NAME.Equals(user) && k.PASSWORD.Equals(pass)).FirstOrDefault();
            if (resultUser != null)
            {
                HttpContext.Current.Session.Add("UserId", resultUser.ID.ToString());
                return resultUser;
            }
            return null;
        }
    }
}
using SalesTransactionApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SalesTransactionApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        [HttpPost]

        public ActionResult Login(LoginViewModel l, string ReturnUrl = "")
        {
            using (DBModel db = new DBModel())
            {
                var users = db.tblUsers.Where(a => a.Username == l.Username && a.Password == l.Password).FirstOrDefault();
                if (users != null)
                {
                    Session.Add("username", users.Username);
                    FormsAuthentication.SetAuthCookie(l.Username, l.RememberMe);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User");
                }
            }
            return View();

        }

        public ActionResult Dashboard()
        {
            return View();
        }
        
    }
}

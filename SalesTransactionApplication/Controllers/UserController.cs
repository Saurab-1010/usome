using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesTransactionApplication.Models;

namespace SalesTransactionApplication.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            using (DBModel db = new DBModel())
            {
                List<AllUserDetail> allList = db.AllUserDetails.ToList<AllUserDetail>();
                return Json(new { data = allList }, JsonRequestBehavior.AllowGet);
            }
                
        }
        

    }
}
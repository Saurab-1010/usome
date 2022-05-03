﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesTransactionApplication.Models;

namespace SalesTransactionApplication.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetData()
        {
            using (DBModel db = new DBModel())
            {
                List<Product> proList = db.Products.ToList<Product>();
                return Json(new { data = proList }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult AddorEdit(int id = 0)
        {
            if(id==0)

            return View(new Product());

            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.Products.Where(x => x.ProductId == id).FirstOrDefault<Product>()) ;
                }
            }
        }

        [HttpPost]
        public ActionResult AddorEdit(Product pro)
        {
            using (DBModel db = new DBModel())
            {
                if (pro.ProductId == 0)
                {
                    db.Products.Add(pro);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Succesfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(pro).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Succesfully" }, JsonRequestBehavior.AllowGet);
                }
            }
                
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Product pro = db.Products.Where(x => x.ProductId == id).FirstOrDefault<Product>();
                db.Products.Remove(pro);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
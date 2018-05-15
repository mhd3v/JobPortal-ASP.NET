using JobPortal_ASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortal_ASP.NET.Controllers
{
    public class AdminController : Controller
    {

        JPDatabaseEntities dc = new JPDatabaseEntities();

        // GET: Admin
       
        public ActionResult Index() {
            return View();
        }

        public ActionResult Dashboard() {

            string id = Request.Form["aId"];
            string pass = Request.Form["pass"];

            var res = (from q in dc.Admins
                       where q.AdminName == id && q.Password == pass
                       select q).SingleOrDefault();

       
            if (res == null) {
                
                ViewBag.Error = "Invalid credentials!";
                return Index();
            }

            else {
                ViewBag.Id = res.AdminName;
                return View();
            }
                
        }

      
    }
}
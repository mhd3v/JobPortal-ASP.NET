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

        public ActionResult Dashboard(LoggedInUser u) {

            if (u.UserName != null) //coming from another page (user logged in already)
                ViewBag.user = u.UserName;

            else {

                string id = Request.Form["aId"];
                string pass = Request.Form["pass"];

                var res = (from q in dc.Admins
                           where q.AdminName == id && q.Password == pass
                           select q).SingleOrDefault();

                if(res != null) 
                    ViewBag.user = res.AdminName;

                
            }

            return View();
            
                
        }
     
      
    }

    public class LoggedInUser {
        public string UserName { get; set; }
    }
}
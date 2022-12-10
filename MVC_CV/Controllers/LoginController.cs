using MVC_CV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_CV.Controllers
{
    [AllowAnonymous] //the controllers that we want to be excluded from the authorize attribution defined in the global.asax
    public class LoginController : Controller
    {
        // GET: Login

        //The reason we use get and post attributes here is that after we click the button, we need to insert to our database only the data we want.Also after the insert process we reload the main page.
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        //This Post attribute works after we click the button
        [HttpPost]
        public ActionResult Index(Tbl_Admin p)
        {
            DbCVEntities db = new DbCVEntities();
            var vUserInfo = db.Tbl_Admin.FirstOrDefault(x => x.UserName == p.UserName &&
            x.Password == p.Password);//if this condition is true then vUserInfo will be return with an value
           
            if (vUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(vUserInfo.UserName, false);//this code grants access authorization.
                Session["UserName"] = vUserInfo.UserName.ToString();

                return RedirectToAction("Index", "Ability");//if uName and pass are true then go to the site
            }

            else
            {
                return RedirectToAction("Index", "Login");//if the inforamtions are false then reloa the login page
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();//is used for sign out process 
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        }
    }
}
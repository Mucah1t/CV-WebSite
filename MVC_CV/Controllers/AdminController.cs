using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    

    public class AdminController : Controller
    {
        // GET: Admin


        //by creating new object from generic repositeries we reached to Ability Class via Generic Repository
        GenericRepositories<Tbl_Admin> repo = new GenericRepositories<Tbl_Admin>();
        public ActionResult Index()
        {
            var vList = repo.List();
            return View(vList);
        }
        [HttpGet] ///The reason we use get and post attributes here is that after we click the button, we need to insert to our database only the data we want.Also after the insert process we reload the main page.
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Tbl_Admin p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            Tbl_Admin t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            Tbl_Admin t = repo.Find(x => x.ID == id);
            return View(t);

        }
        [HttpPost]
        public ActionResult UpdateAdmin(Tbl_Admin p)
        {
            Tbl_Admin t = repo.Find(x => x.ID == p.ID);
            t.UserName = p.UserName;
            t.Password = p.Password;
         
            repo.TUpdate(t);

            return RedirectToAction("Index");


        }
    }
}
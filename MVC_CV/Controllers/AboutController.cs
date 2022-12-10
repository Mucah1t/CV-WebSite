using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        //by creating new object from generic repositeries we reached to Ability Class via Generic Repository
        GenericRepositories<Tbl_About> repo = new GenericRepositories<Tbl_About>();


        //The reason we use get and post attributes here is that after we click the button, we need to insert to our database only the data we want.Also after the insert process we reload the main page.
        [HttpGet]
        public ActionResult Index()
        {
            var vAbout = repo.List();
            return View(vAbout);
        }
        //This Post attribute works after we click the button to be able make desired CRUD operation
        [HttpPost]
        public ActionResult Index(Tbl_About p)
        {
            var v = repo.Find(x => x.ID == 1);
            v.Name = p.Name;
            v.LastName = p.LastName;
            v.Adress = p.Adress;
            v.Mail = p.Mail;
            v.Phone = p.Phone;
            v.Statement = p.Statement;
            v.Picture = p.Picture;


            repo.TUpdate(v);

            return RedirectToAction("Index");
        }
    }
}
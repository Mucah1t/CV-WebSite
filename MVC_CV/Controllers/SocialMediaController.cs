using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia

        //by creating new object from generic repositeries we reached to SocialMedia Class via Generic Repository
        GenericRepositories<Tbl_SocialMedia> repo = new GenericRepositories<Tbl_SocialMedia>();

        //Listing SQL Datas by means of GenericRepositories class which includes CRUD Operaiton
        public ActionResult Index()
        {
            var vSocMedia = repo.List();
            return View(vSocMedia);
        }
        //The reason we use get and post attributes here is that after we click the button, we need to insert to our database only the data we want.Also after the insert process we reload the main page.
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        //This Post attribute works after we click the button
        [HttpPost]
        public ActionResult Add(Tbl_SocialMedia p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");

        }
        //Get and Post attributes are required for Update operation as well
        [HttpGet]
        public ActionResult UpdateSocMedia(int id)
        {
            var vSoc = repo.Find(x => x.ID == id);  //Assigning id to vSocMedia
            return View(vSoc);
        }

        [HttpPost]
        public ActionResult UpdateSocMedia(Tbl_SocialMedia p)
        {
            var v = repo.Find(x => x.ID == p.ID);
            v.Name = p.Name;
            v.Link = p.Link;
            v.Icon = p.Icon;
            v.Statu = true;

            repo.TUpdate(v);

            return RedirectToAction("Index");
        }
        public ActionResult Remove(int id)
        {
            var vSocMedia=repo.Find(x => x.ID == id);
            vSocMedia.Statu = false;

            repo.TUpdate(vSocMedia);
            return RedirectToAction("Index");

        }

    }
}
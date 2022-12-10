using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;
using MVC_CV.Repositories;

namespace MVC_CV.Controllers
{
    public class AwardController : Controller
    {
        // GET: Award

        //by creating new object from generic repositeries we reached to Ability Class via Generic Repository
        GenericRepositories<Tbl_Awards> repo = new GenericRepositories<Tbl_Awards>();

        //Listing SQL Datas by means of GenericRepositories class which includes CRUD Operaiton
        public ActionResult Index()
        {
            var vAward = repo.List();
            return View(vAward);
        }


        //Get and Post attributes are required for Update operation as well
        [HttpGet]
        public ActionResult UpdateAward(int id) //CRUD "Update Operaiton"
        {
            var vAward = repo.Find(x => x.ID == id); //Assigning id to vAbility

            ViewBag.d = id; //Viewbag was used to move the id to be able to delete

            return View(vAward); //Returning vAbility
        }
        [HttpPost]
        public ActionResult UpdateAward(Tbl_Awards p)
        {             
            var v = repo.Find(x => x.ID == p.ID);
            v.Statement = p.Statement;
            v.Date = p.Date;

            repo.TUpdate(v);

            return RedirectToAction("Index"); // to go back to the page after the Update operation
        }

        //The reason we use get and post attributes here is that after we click the button, we need to insert to our database only the data we want.Also after the insert process we reload the main page.
        [HttpGet]
        public ActionResult AddAward() //CRUD "Insert Operaiton"
        {
            return View();
        }
        //This Post attribute works after we click the button
        [HttpPost]
        public ActionResult AddAward(Tbl_Awards p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAward(int id) //You will get an id from outside
        {
            var vAward = repo.Find(x => x.ID == id); //Then the id will be found  and assigned to var
            repo.TDelete(vAward);

            return RedirectToAction("Index");
        }


    }
}
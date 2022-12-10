using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;
using MVC_CV.Repositories;

namespace MVC_CV.Controllers
{
    public class AbilityController : Controller
    {
        // GET: Ability


        //by creating new object from generic repositeries we reached to Ability Class via Generic Repository
        GenericRepositories<Tbl_Ability> repo = new GenericRepositories<Tbl_Ability>();

        //Listing SQL Datas by means of GenericRepositories class which includes CRUD Operaiton
        public ActionResult Index()
        {
            var vAbility = repo.List();
            return View(vAbility);
        }

         //The reason we use get and post attributes here is that after we click the button, we need to insert to our database only the data we want.Also after the insert process we reload the main page.
        [HttpGet]
        public ActionResult AddAbility() //Adding view to AddAbility here
        {
            return View();
        }
        //This Post attribute works after we click the button
        [HttpPost]
        public ActionResult AddAbility(Tbl_Ability p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        
        public ActionResult DeleteAbility(int id)
        {
            //We need an id to delete any data from our database. In this regard we use "Find" method.
            var vAbility = repo.Find(x => x.ID == id);
            repo.TDelete(vAbility);

            return RedirectToAction("Index"); //To go back to the page after the operaion 
        }

        //Get and Post attributes are required for Update operation as well
        [HttpGet]
        public ActionResult UpdateAbility(int id)
        {
            var vAbility = repo.Find(x => x.ID == id); //Assigning id to vAbility
            return View(vAbility); //Returning vAbility
        }
        [HttpPost]
        public ActionResult UpdateAbility(Tbl_Ability p)
        {
            var v = repo.Find(x => x.ID == p.ID);
            v.Ability = p.Ability; //p stands for parameter so we are gonna replace new values with existince
            v.Proportion = p.Proportion;

            repo.TUpdate(v);

            return RedirectToAction("Index");
        }


    }
}
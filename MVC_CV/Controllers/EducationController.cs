using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    [Authorize] //It is used for restriction on pages where access is not authorized.
    public class EducationController : Controller
    {
        // GET: Education

        //by creating new object from generic repositeries we reached to Ability Class via Generic Repository
        GenericRepositories<Tbl_Education> repo = new GenericRepositories<Tbl_Education>();

       
        public ActionResult Index()
        {
            var vEducation = repo.List();
            return View(vEducation);
        }

        //The reason we use get and post attributes here is that after we click the button, we need to insert to our database only the data we want.Also after the insert process we reload the main page.
        [HttpGet]
        public ActionResult AddEducation() //Adding new view to AddEducation here
        {
            return View();

        }

        //This Post attribute works after we click the button
        [HttpPost]
        public ActionResult AddEducation(Tbl_Education p)
        {
            if (!ModelState.IsValid) //if the state validity of the model is not established
            {
                return View("AddEducation");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id)
        {
            //We need an id to delete any data from our database. In this regard we use "Find" method.
            var vEducation = repo.Find(x => x.ID == id);
            repo.TDelete(vEducation);

            return RedirectToAction("Index"); //To go back to the page after the operaion 
           
        }

        //Get and Post attributes are required for Update operation as well
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var vEducation = repo.Find(x => x.ID == id); //Assigning id to vAbility
            return View(vEducation); //Returning vAbility
        }
        [HttpPost]
        public ActionResult UpdateEducation(Tbl_Education p)
        {
            //Validation Control
            if (!ModelState.IsValid) //if the state validity of the model is not established
            {
                return View("UpdateEducation");
            }


            var v = repo.Find(x => x.ID == p.ID);
            v.Title = p.Title;
            v.SubTitle1 = p.SubTitle1;
            v.SubTitle2 = p.SubTitle2;
            v.GPA = p.GPA;
            v.Date = p.Date;

            repo.TUpdate(v);

            return RedirectToAction("Index");
        }
    }
}
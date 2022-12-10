using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;

namespace MVC_CV.Controllers
{
    [AllowAnonymous] //the controllers that we want to be excluded from the authorize attribution defined in the global.asax

    public class DefaultController : Controller
    {
        // GET: Default
        DbCVEntities db = new DbCVEntities(); //Cretaing an object from Entity to be able to CRUD operations
        public ActionResult Index()
        {
            var vValues = db.Tbl_About.ToList();
            return View(vValues);
        }
        public PartialViewResult Experience() //the reason we use partial vies is that only 1 ActionResult is allowed in 1 page
        {
            var vExperience = db.Tbl_Experience.ToList(); //Assigning vExperience values with all datas from SQL
            return PartialView(vExperience);//Returning the vExperince so we can list the datas
        }
        public PartialViewResult SocialMedia()
        {
            var vSocMedia = db.Tbl_SocialMedia.Where(x=>x.Statu==true).ToList(); //To be able to list only avtive Social Medias
            return PartialView(vSocMedia);
        }
        public PartialViewResult Education()
        {
            var vEducation = db.Tbl_Education.ToList();
            return PartialView(vEducation);
        }
        public PartialViewResult Ability()
        {
            var vAbility = db.Tbl_Ability.ToList();
            return PartialView(vAbility);
        }
        public PartialViewResult Interest()
        {
            var vHobies = db.Tbl_Hobies.ToList();
            return PartialView( vHobies);
        }
        public PartialViewResult Awards()
        {
            var vAwards = db.Tbl_Awards.ToList();
            return PartialView(vAwards);
        }
        //The reason we use get and post attributes here is that after we click the button, we need to insert to our database only the data we want.Also after the insert process we reload the main page.
        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        //This Post attribute works after we click the button
        [HttpPost]
        public PartialViewResult Contact(Tbl_Contact c)
        {
            db.Tbl_Contact.Add(c);
            db.SaveChanges();

            c.Date = DateTime.Parse(DateTime.Now.ToShortDateString()); //Using the exact date as parameter so we can also insert to "Date" column

            return PartialView();
        }
    }
}
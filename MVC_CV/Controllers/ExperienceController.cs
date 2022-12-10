using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI;

namespace MVC_CV.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience

        ExperienceRepository rep = new ExperienceRepository();
        public ActionResult Index()
        {
            var vValues = rep.List();
            return View(vValues);
        }
        [HttpGet] ///The reason we use get and post attributes here is that after we click the button, we need to insert to our database only the data we want.Also after the insert process we reload the main page.
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(Tbl_Experience p)
        {
            rep.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteExperience(int id)
        {
            Tbl_Experience t = rep.Find(x => x.ID == id);
            rep.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            Tbl_Experience t = rep.Find(x => x.ID == id);
            return View(t);

        }
        [HttpPost]
        public ActionResult UpdateExperience(Tbl_Experience p)
        {
            Tbl_Experience t = rep.Find(x => x.ID == p.ID);
            t.Title = p.Title;
            t.SubTitle = p.SubTitle;
            t.Date = p.Date;
            t.Explanation = p.Explanation;

            rep.TUpdate(t);

            return RedirectToAction("Index");


        }
    }
}
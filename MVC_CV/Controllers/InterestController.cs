using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CV.Controllers
{
    public class InterestController : Controller
    {
        // GET: Interest

        //by creating new object from generic repositeries we reached to Ability Class via Generic Repository
        GenericRepositories<Tbl_Hobies> repo = new GenericRepositories<Tbl_Hobies>();


        //The reason we use get and post attributes here is that after we click the button, we need to insert to our database only the data we want.Also after the insert process we reload the main page.
        [HttpGet]
        public ActionResult Index()
        {
            var vInterest = repo.List();
            return View(vInterest);
        }
        //This Post attribute works after we click the button to be able make desired CRUD operation
        [HttpPost]
        public ActionResult Index(Tbl_Hobies p)
        {
            var v = repo.Find(x => x.ID == 1);
            v.Statement1 = p.Statement1;
            v.Statement2 = p.Statement2;

            repo.TUpdate(v);

            return RedirectToAction("Index");
        }
    }
}
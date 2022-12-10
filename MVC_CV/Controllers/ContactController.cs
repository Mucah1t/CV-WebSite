using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CV.Models.Entity;
using MVC_CV.Repositories;
namespace MVC_CV.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        //by creating new object from generic repositeries we reached to Ability Class via Generic Repository
        GenericRepositories<Tbl_Contact> repo = new GenericRepositories<Tbl_Contact>();
        public ActionResult Index()
        {
            var vMessage = repo.List();
            return View(vMessage);
        }
    }
}
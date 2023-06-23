using McvCv.Models.Entity;
using McvCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvCv.Controllers
{
    public class AboutController : Controller
    {
        GenericRepository<TblAbout> repo = new GenericRepository<TblAbout>();

        [HttpGet]
        public ActionResult Index()
        {
            var abouts = repo.GetAll();
            return View(abouts);
        }

        [HttpPost]
        public ActionResult Index(TblAbout p)
        {
            var t = repo.Get(x => x.Id == 1);
            t.FirstName = p.FirstName;
            t.LastName = p.LastName;
            t.Address = p.Address;
            t.Mail = p.Mail;
            t.PhoneNumber = p.PhoneNumber;
            t.Description = p.Description;
            t.Image = p.Image;
            repo.Update(t);

            return RedirectToAction("Index");
        }
    }
}

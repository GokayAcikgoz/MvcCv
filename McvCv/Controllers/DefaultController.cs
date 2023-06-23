using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McvCv.Models.Entity;

namespace McvCv.Controllers
{
    [AllowAnonymous] //Bu sayfayı proje bazında auth dan muaf tutar.
    public class DefaultController : Controller
    {

        DbCvEntities db = new DbCvEntities();

        // GET: Default
        public ActionResult Index()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }

        public PartialViewResult SocialMedia()
        {

            var socialMedia = db.TblSocial.Where(x => x.Status == true).ToList();
            return PartialView(socialMedia);
        }

        public PartialViewResult Experience() //Bir sayfada birden çok bölüm varsa bu şekilde partialView
        {

            var values = db.TblExperience.ToList();
            return PartialView(values);
        }

        public PartialViewResult Education()
        {

            var values = db.TblEducation.ToList();
            return PartialView(values);
        }

        public PartialViewResult Skill()
        {

            var values = db.TblSkills.ToList();
            return PartialView(values);
        }

        public PartialViewResult Hobby()
        {

            var values = db.TblInterests.ToList();
            return PartialView(values);
        }

        public PartialViewResult Certificate()
        {

            var values = db.TblCertificates.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult Contact()
        {
            
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Contact(TblContact t)
        {
            t.Date =DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblContact.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}
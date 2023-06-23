using McvCv.Models.Entity;
using McvCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvCv.Controllers
{
    [Authorize]//Proje seviyesine çıkarmak için global.axas gittik.
    public class EducationController : Controller
    {
        // GET: Education

        GenericRepository<TblEducation> repo = new GenericRepository<TblEducation>();

        
        public ActionResult Index()
        {
            var education = repo.GetAll();
            return View(education);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEducation(TblEducation education)
        {
            if(!ModelState.IsValid)
            {
                return View("AddEducation");
            }
            repo.Add(education);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            TblEducation t = repo.Get(x => x.Id == id);
            repo.Delete(t);

            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var education = repo.Get(x => x.Id == id);
            return View(education);
        }

        [HttpPost]
        public ActionResult UpdateEducation(TblEducation t)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateEducation");
            }

            var education = repo.Get(x => x.Id == t.Id);
            education.Title = t.Title;
            education.Subtitle = t.Subtitle;
            education.Subtitle2 = t.Subtitle2;
            education.GPA = t.GPA;
            education.Date = t.Date;
            
            repo.Update(education);
            return RedirectToAction("Index");
        }
    }
}
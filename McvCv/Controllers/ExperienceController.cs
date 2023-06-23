using McvCv.Models.Entity;
using McvCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvCv.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
       
        ExperienceRepository repo = new ExperienceRepository();

        public ActionResult Index()
        {
            var value = repo.GetAll();

            return View(value);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(TblExperience experience)
        {
            repo.Add(experience);
            return RedirectToAction("Index"); //ekleme işleminden sonra indexe yönlendir.
        }

        public ActionResult DeleteExperience(int id) 
        {
            TblExperience t = repo.Get(x => x.Id == id);
            repo.Delete(t);

            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public ActionResult GetExperience(int id)
        {
            TblExperience t = repo.Get(x => x.Id == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult GetExperience(TblExperience experience)
        {
            TblExperience t = repo.Get(x => x.Id == experience.Id);
            t.Title = experience.Title;
            t.SubTitle = experience.SubTitle;
            t.Date = experience.Date;
            t.Description = experience.Description;
            repo.Update(t);
            return RedirectToAction("Index");
        }
    }
}
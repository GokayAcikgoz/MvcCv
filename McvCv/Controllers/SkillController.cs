using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McvCv.Models.Entity;
using McvCv.Repositories;

namespace McvCv.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        GenericRepository<TblSkills> repo = new GenericRepository<TblSkills>();
        public ActionResult Index()
        {
            var skills = repo.GetAll();
            return View(skills);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(TblSkills skills)
        {
            repo.Add(skills);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            var skill = repo.Get(x => x.Id == id);
            repo.Delete(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id) 
        {
            var skill = repo.Get(x => x.Id == id);
            return View(skill);
        }

        [HttpPost]
        public ActionResult UpdateSkill(TblSkills skills)
        {
            var skill = repo.Get(x => x.Id == skills.Id);
            skill.Talent = skills.Talent;
            skill.Progress = skills.Progress;
            repo.Update(skill);
            return RedirectToAction("Index");
        }
    }
}
using McvCv.Models.Entity;
using McvCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvCv.Controllers
{
    public class HobbyController : Controller
    {
        // GET: Hobby
        GenericRepository<TblInterests> repo = new GenericRepository<TblInterests>();

        [HttpGet]
        public ActionResult Index()
        {
            var hobbies = repo.GetAll();
            return View(hobbies);
        }

        [HttpPost]
        public ActionResult Index(TblInterests p)
        {
            var t = repo.Get(x => x.Id == 1);
            t.Description1 = p.Description1;
            t.Description2 = p.Description2;
            repo.Update(t);

            return RedirectToAction("Index");
        }
    }
}
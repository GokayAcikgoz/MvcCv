using McvCv.Models.Entity;
using McvCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvCv.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia

        GenericRepository<TblSocial> repo = new GenericRepository<TblSocial>();
        public ActionResult Index()
        {
            var data = repo.GetAll();
            return View(data);
        }

        [HttpGet]
        public ActionResult AddSocial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSocial(TblSocial p)
        {
            repo.Add(p);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSocial(int id)
        {
            var account = repo.Get(x => x.ID ==  id);
            return View(account);
        }

        [HttpPost]
        public ActionResult UpdateSocial(TblSocial p)
        {
            var account = repo.Get(x => x.ID == p.ID);
            account.Name = p.Name;
            account.Icon = p.Icon;
            account.Link = p.Link;
            repo.Update(account);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocial(int id)
        {
            var status = repo.Get(x => x.ID == id);
            if(status.Status == true)
            {
                status.Status = false;
            }
            else if(status.Status == false)
            {
                status.Status = true;
            }
            repo.Update(status);
            return RedirectToAction("Index");        
        }
    }
}
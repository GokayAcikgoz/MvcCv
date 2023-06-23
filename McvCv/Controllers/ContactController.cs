using McvCv.Models.Entity;
using McvCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace McvCv.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        GenericRepository<TblContact> repo = new GenericRepository<TblContact>();
        public ActionResult Index()
        {
            var messages = repo.GetAll();
            return View(messages);
        }
    }
}
using McvCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace McvCv.Controllers
{
    [AllowAnonymous] //Bu sayfayı proje bazında auth dan muaf tutar.
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin p)
        {
            DbCvEntities db = new DbCvEntities();
            var bilgi = db.TblAdmin.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.UserName, false);
                Session["UserName"] = bilgi.UserName.ToString();
                return RedirectToAction("Index", "Experience");  //web.config ekleme yapıldı.
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}
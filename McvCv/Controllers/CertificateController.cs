using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McvCv.Models.Entity;
using McvCv.Repositories;

namespace McvCv.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate

        GenericRepository<TblCertificates> repo = new GenericRepository<TblCertificates>();
        public ActionResult Index()
        {
            var certificate = repo.GetAll();
            return View(certificate);
        }

        [HttpGet]
        public ActionResult GetCertificate(int id)
        {
            var certificate = repo.Get(x => x.Id == id);
            return View(certificate);
        }

        [HttpPost]
        public ActionResult GetCertificate(TblCertificates certificates)
        {
            var certificate = repo.Get(x => x.Id == certificates.Id);
            certificate.Description = certificates.Description;
            certificate.Date = certificates.Date;
            repo.Update(certificate);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCertificate(TblCertificates certificates)
        {
            repo.Add(certificates);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCertificate(int id)
        {
            var certificate = repo.Get(x => x.Id == id);
            repo.Delete(certificate);
            return RedirectToAction("Index");
        }
    }
}
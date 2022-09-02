using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Models.Sinif;

namespace MvcCV.Controllers
{
    public class DeneyimlerController : Controller
    {
        // GET: Deneyimler
        MvcCVSitesiDBEntities db = new MvcCVSitesiDBEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.deger2 = db.TblExperience.ToList();
            return View(cs);
        }

        [HttpGet]
        public ActionResult yeniDeneyim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yeniDeneyim(TblExperience deneyim)
        {
            db.TblExperience.Add(deneyim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult deneyimSil(int id)
        {
            var deneyim = db.TblExperience.Find(id);
            db.TblExperience.Remove(deneyim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult deneyimGetir(int id)
        {
            var deneyim = db.TblExperience.Find(id);
            return View("deneyimGetir", deneyim);
        }

        public ActionResult deneyimGuncelle(TblExperience x)
        {
            var deneyim = db.TblExperience.Find(x.ID);
            deneyim.TITLE = x.TITLE;
            deneyim.SUBTITLE = x.SUBTITLE;
            deneyim.DETAILS = x.DETAILS;
            deneyim.DATE = x.DATE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
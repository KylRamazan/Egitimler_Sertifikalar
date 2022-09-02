using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Models.Sinif;

namespace MvcCV.Controllers
{
    public class EgitimHayatimController : Controller
    {
        // GET: EgitimHayatim
        MvcCVSitesiDBEntities db = new MvcCVSitesiDBEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.deger3 = db.TblEducation.ToList();
            return View(cs);
        }

        [HttpGet]
        public ActionResult yeniEgitim()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yeniEgitim(TblEducation egitim)
        {
            db.TblEducation.Add(egitim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult egitimSil(int id)
        {
            var egitim = db.TblEducation.Find(id);
            db.TblEducation.Remove(egitim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult egitimGetir(int id)
        {
            var egitim = db.TblEducation.Find(id);
            return View("egitimGetir", egitim);
        }

        public ActionResult egitimGuncelle(TblEducation x)
        {
            var egitim = db.TblEducation.Find(x.ID);
            egitim.TITLE = x.TITLE;
            egitim.SUBTITLE = x.SUBTITLE;
            egitim.DEPARTMENT = x.DEPARTMENT;
            egitim.GPA = x.GPA;
            egitim.DATE = x.DATE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Models.Sinif;

namespace MvcCV.Controllers
{
    public class HobilerController : Controller
    {
        // GET: Hobiler
        MvcCVSitesiDBEntities db = new MvcCVSitesiDBEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.deger5 = db.TblInterests.ToList();
            return View(cs);
        }

        [HttpGet]
        public ActionResult yeniHobi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yeniHobi(TblInterests hobi)
        {
            db.TblInterests.Add(hobi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult hobiSil(int id)
        {
            var hobi = db.TblInterests.Find(id);
            db.TblInterests.Remove(hobi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult hobiGetir(int id)
        {
            var hobi = db.TblInterests.Find(id);
            return View("hobiGetir", hobi);
        }

        public ActionResult hobiGuncelle(TblInterests x)
        {
            var hobi = db.TblInterests.Find(x.ID);
            hobi.INTEREST = x.INTEREST;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
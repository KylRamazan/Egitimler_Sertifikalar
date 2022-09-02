using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Models.Sinif;

namespace MvcCV.Controllers
{
    public class KonferanslarController : Controller
    {
        // GET: Konferanslar
        MvcCVSitesiDBEntities db = new MvcCVSitesiDBEntities();
        public ActionResult Index(string x)
        {
            var konferans=from d in db.TblAwards select d;
            if(!string.IsNullOrEmpty(x))
            {
                konferans = konferans.Where(m => m.AWARD.Contains(x));
            }
            return View(konferans.ToList());
        }

        [HttpGet]
        public ActionResult yeniKonferans()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yeniKonferans(TblAwards konferans)
        {
            db.TblAwards.Add(konferans);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult konferansSil(int id)
        {
            var konferans = db.TblAwards.Find(id);
            db.TblAwards.Remove(konferans);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult konferansGetir(int id)
        {
            var konferans = db.TblAwards.Find(id);
            return View("konferansGetir", konferans);
        }

        public ActionResult konferansGuncelle(TblAwards x)
        {
            var konferans = db.TblAwards.Find(x.ID);
            konferans.AWARD = x.AWARD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
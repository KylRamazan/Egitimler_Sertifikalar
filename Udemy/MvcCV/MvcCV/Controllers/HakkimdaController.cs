using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Models.Sinif;

namespace MvcCV.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        MvcCVSitesiDBEntities db = new MvcCVSitesiDBEntities();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.deger1 =db.TblAbout.ToList();
            return View(cs);
        }

        public ActionResult hakkimdaGetir(int id)
        {
            var hakkimda = db.TblAbout.Find(id);
            return View("hakkimdaGetir",hakkimda);
        }

        public ActionResult hakkimdaGuncelle(TblAbout x)
        {
            var hakkimda = db.TblAbout.Find(x.ID);
            hakkimda.NAME = x.NAME;
            hakkimda.SURNAME = x.SURNAME;
            hakkimda.ADDRESS = x.ADDRESS;
            hakkimda.PHONE = x.PHONE;
            hakkimda.MAIL = x.MAIL;
            hakkimda.ABOUT = x.ABOUT;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
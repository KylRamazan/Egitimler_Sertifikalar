using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class OgrencilerController : Controller
    {
        // GET: Ogrenciler
        MvcOkulDBEntities db = new MvcOkulDBEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.TblOgrenciler.ToList();
            return View(ogrenciler);
        }

        [HttpGet]
        public ActionResult yeniOgrenci()
        {
            List<SelectListItem> kulupler = (from x in db.TblKulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KULUPAD,
                                                 Value = x.KULUPID.ToString()
                                             }).ToList();
            ViewBag.deger = kulupler;
            return View();
        }

        [HttpPost]
        public ActionResult yeniOgrenci(TblOgrenciler Ogrenci)
        {
            var kulup =db.TblKulupler.Where(x=>x.KULUPID==Ogrenci.TblKulupler.KULUPID).FirstOrDefault();
            Ogrenci.TblKulupler =kulup;
            db.TblOgrenciler.Add(Ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ogrenciSil(int id)
        {
            var ogrenci = db.TblOgrenciler.Find(id);
            db.TblOgrenciler.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ogrenciGuncelle(TblOgrenciler ogr)
        {
            var ogrenci = db.TblOgrenciler.Find(ogr.OGRID);
            ogrenci.OGRAD = ogr.OGRAD;
            ogrenci.OGRSOYAD = ogr.OGRSOYAD;
            ogrenci.OGRFOTOGRAF = ogr.OGRFOTOGRAF;
            ogrenci.OGRCINSIYET = ogr.OGRCINSIYET;
            ogrenci.OGRKULUP = ogr.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ogrenciGetir(int id)
        {
            var ogrenci = db.TblOgrenciler.Find(id);
            List<SelectListItem> kulupler = (from x in db.TblKulupler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KULUPAD,
                                                 Value = x.KULUPID.ToString()
                                             }).ToList();
            ViewBag.deger = kulupler;
            return View("ogrenciGetir",ogrenci);
        }
    }
}
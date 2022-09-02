using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        public ActionResult Index()
        {
            var degerler = db.TblYazarlar.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult yazarEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yazarEkle(TblYazarlar x)
        {
            if(!ModelState.IsValid)
            {
                return View("yazarEkle");
            }
            db.TblYazarlar.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult yazarSil(int id)
        {
            var yazar = db.TblYazarlar.Find(id);
            db.TblYazarlar.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult yazarGetir(int id)
        {
            var yazar = db.TblYazarlar.Find(id);
            return View("yazarGetir", yazar);
        }

        public ActionResult yazarGuncelle(TblYazarlar x)
        {
            if (!ModelState.IsValid)
            {
                return View("yazarGetir");
            }
            var yazar = db.TblYazarlar.Find(x.ID);
            yazar.AD = x.AD;
            yazar.SOYAD = x.SOYAD;
            yazar.DETAY = x.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult yazarKitaplar(int id)
        {
            var yazar =db.TblKitaplar.Where(x=>x.YAZAR==id).ToList();
            var yazarAdi =db.TblYazarlar.Where(x=>x.ID==id).Select(y=>y.AD +" "+y.SOYAD).FirstOrDefault();
            ViewBag.deger = yazarAdi;
            return View(yazar);
        }

    }
}
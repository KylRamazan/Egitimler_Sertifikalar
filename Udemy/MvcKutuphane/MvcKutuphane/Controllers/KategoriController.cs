using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        public ActionResult Index()
        {
            var degerler = db.TblKategoriler.Where(x=>x.DURUM==true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult kategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult kategoriEkle(TblKategoriler x)
        {
            db.TblKategoriler.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult kategoriSil(int id)
        {
            var kategori = db.TblKategoriler.Find(id);
            //db.TblKategoriler.Remove(kategori);
            kategori.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult kategoriGetir(int id)
        {
            var kategori = db.TblKategoriler.Find(id);
            return View("kategoriGetir",kategori);
        }

        public ActionResult kategoriGuncelle(TblKategoriler x)
        {
            var kategori = db.TblKategoriler.Find(x.ID);
            kategori.AD = x.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
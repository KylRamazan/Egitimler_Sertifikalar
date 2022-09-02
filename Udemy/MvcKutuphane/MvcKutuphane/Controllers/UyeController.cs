using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using PagedList.Mvc;
using PagedList;

namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.TblUyeler.ToList().ToPagedList(sayfa,5);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult uyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult uyeEkle(TblUyeler x)
        {
            if (!ModelState.IsValid)
            {
                return View("uyeEkle");
            }
            db.TblUyeler.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult uyeSil(int id)
        {
            var uye = db.TblUyeler.Find(id);
            db.TblUyeler.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult uyeGetir(int id)
        {
            var uye = db.TblUyeler.Find(id);
            return View("uyeGetir", uye);
        }

        public ActionResult uyeGuncelle(TblUyeler x)
        {
            if (!ModelState.IsValid)
            {
                return View("uyeGetir");
            }
            var uye = db.TblUyeler.Find(x.ID);
            uye.AD = x.AD;
            uye.SOYAD = x.SOYAD;
            uye.MAIL = x.MAIL;
            uye.KULLANICIADI = x.KULLANICIADI;
            uye.SIFRE = x.SIFRE;
            uye.FOTOGRAF = x.FOTOGRAF;
            uye.TELEFON = x.TELEFON;
            uye.OKUL = x.OKUL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult uyeKitapGecmis(int id)
        {
            var kitapGecmis =db.TblHareketler.Where(x=>x.UYE==id).ToList();
            var uyeKitap = db.TblUyeler.Where(x => x.ID == id).Select(y => y.AD + " " + y.SOYAD).FirstOrDefault();
            ViewBag.deger = uyeKitap;
            return View(kitapGecmis);
        }
    }
}
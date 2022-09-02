using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        public ActionResult Index(string p)
        {
            var degerler = from x in db.TblKitaplar select x;
            if(!string.IsNullOrEmpty(p))
            {
                degerler =degerler.Where(m=>m.AD.Contains(p));
            }
            return View(degerler.ToList());
        }

        [HttpGet]
        public ActionResult kitapEkle()
        {
            List<SelectListItem> deger=(from x in db.TblKategoriler.ToList()
                                        select new SelectListItem
                                        {
                                            Text=x.AD,
                                            Value=x.ID.ToString()
                                        }).ToList();

            List<SelectListItem> deger2 = (from x in db.TblYazarlar.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.AD +" "+ x.SOYAD,
                                              Value = x.ID.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;
            ViewBag.dgr2 = deger2;
            return View();
        }

        [HttpPost]
        public ActionResult kitapEkle(TblKitaplar x)
        {
            var kategori =db.TblKategoriler.Where(k=>k.ID==x.TblKategoriler.ID).FirstOrDefault();
            var yazar =db.TblYazarlar.Where(y=>y.ID==x.TblYazarlar.ID).FirstOrDefault();
            x.TblKategoriler =kategori;
            x.TblYazarlar = yazar;
            x.DURUM = true;
            db.TblKitaplar.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult kitapSil(int id)
        {
            var kitap = db.TblKitaplar.Find(id);
            db.TblKitaplar.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult kitapGetir(int id)
        {
            var kitap = db.TblKitaplar.Find(id);
            List<SelectListItem> deger = (from x in db.TblKategoriler.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.AD,
                                              Value = x.ID.ToString()
                                          }).ToList();

            List<SelectListItem> deger2 = (from x in db.TblYazarlar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD + " " + x.SOYAD,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.dgr = deger;
            ViewBag.dgr2 = deger2;
            return View("kitapGetir", kitap);
        }
        
        public ActionResult kitapGuncelle(TblKitaplar x)
        {
            var kitap = db.TblKitaplar.Find(x.ID);
            var kategori =db.TblKategoriler.Where(k=>k.ID==x.TblKategoriler.ID).FirstOrDefault();
            var yazar =db.TblYazarlar.Where(y=>y.ID==x.TblYazarlar.ID).FirstOrDefault();
            kitap.AD = x.AD;
            kitap.YAZAR = yazar.ID;
            kitap.KATEGORI = kategori.ID;
            kitap.BASIMYIL = x.BASIMYIL;
            kitap.YAYINEVI = x.YAYINEVI;
            kitap.SAYFASAYISI = x.SAYFASAYISI;
            kitap.KITAPGORSEL = x.KITAPGORSEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        } 
    }
}
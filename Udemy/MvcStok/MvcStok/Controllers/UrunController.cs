using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcStokDBEntities db = new MvcStokDBEntities();
        [Authorize]
        public ActionResult Index(string p)
        {
            var urunler =db.TblUrunler.Where(x=>x.DURUM==true);
            if(!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(x => x.AD.Contains(p) && x.DURUM == true);
            }

            return View(urunler.ToList());
        }

        [HttpGet]
        [Authorize]
        public ActionResult yeniUrun()
        {
            List<SelectListItem> kategori = (from x in db.TblKategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text =x.AD,
                                                 Value=x.ID.ToString()
                                             }).ToList();
            ViewBag.deger = kategori;
            return View();
        }

        [HttpPost]
        public ActionResult yeniUrun(TblUrunler urun)
        {
            var kategori =db.TblKategoriler.Where(x=>x.ID==urun.TblKategoriler.ID).FirstOrDefault();
            urun.TblKategoriler = kategori;
            urun.DURUM = true;
            db.TblUrunler.Add(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult urunSil(TblUrunler urun)
        {
            var urunBul = db.TblUrunler.Find(urun.ID);
            urunBul.DURUM = false; 
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult urunGetir(int id)
        {
            List<SelectListItem> kategori = (from x in db.TblKategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.AD,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.ktgr = kategori;
            var urun = db.TblUrunler.Find(id);
            return View("urunGetir", urun);
        }

        [Authorize]
        public ActionResult urunGuncelle(TblUrunler urun)
        {
            var urn = db.TblUrunler.Find(urun.ID);
            urn.AD = urun.AD;
            urn.MARKA = urun.MARKA;
            urn.STOK = urun.STOK;
            urn.ALISFIYAT = urun.ALISFIYAT;
            urn.SATISFIYAT = urun.SATISFIYAT;
            var kategori = db.TblKategoriler.Where(x => x.ID == urun.TblKategoriler.ID).FirstOrDefault();
            urn.KATEGORI = kategori.ID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
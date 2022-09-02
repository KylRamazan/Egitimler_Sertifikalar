using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcStokDBEntities db = new MvcStokDBEntities();
        [Authorize]
        public ActionResult Index()
        {
            var satis = db.TblSatislar.ToList();
            return View(satis);
        }

        [HttpGet]
        [Authorize]
        public ActionResult yeniSatis()
        {
            // Ürünler
            List<SelectListItem> urun = (from x in db.TblUrunler.Where(x=>x.DURUM==true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.AD,
                                                 Value = x.ID.ToString()
                                             }).ToList();
            ViewBag.deger = urun;

            // Personeller
            List<SelectListItem> personel = (from x in db.TblPersoneller.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.AD +" "+ x.SOYAD,
                                             Value = x.ID.ToString()
                                         }).ToList();
            ViewBag.deger2 = personel;

            // Müşteriler
            List<SelectListItem> musteri = (from x in db.TblMusteriler.Where(x => x.DURUM == true).ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.AD + " " + x.SOYAD,
                                             Value = x.ID.ToString()
                                         }).ToList();
            ViewBag.deger3 = musteri;

            return View();
        }

        [HttpPost]
        public ActionResult yeniSatis(TblSatislar satis)
        {
            var urun =db.TblUrunler.Where(x=>x.ID==satis.TblUrunler.ID).FirstOrDefault();
            var personel =db.TblPersoneller.Where(x=>x.ID==satis.TblPersoneller.ID).FirstOrDefault();
            var musteri =db.TblMusteriler.Where(x=>x.ID==satis.TblMusteriler.ID).FirstOrDefault();
            satis.TblUrunler = urun;
            satis.TblPersoneller = personel;
            satis.TblMusteriler = musteri;
            satis.TARIH =DateTime.Now;
            db.TblSatislar.Add(satis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
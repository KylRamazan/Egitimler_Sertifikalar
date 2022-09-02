using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class OduncKitapVermeController : Controller
    {
        // GET: OduncKitapVerme
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHareketler.Where(x => x.ISLEMDURUM == false).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult oduncVer()
        {
            List<SelectListItem> deger1 =(from x in db.TblUyeler.ToList()
                                          select new SelectListItem
                                          {
                                              Text=x.AD+ " "+ x.SOYAD,
                                              Value=x.ID.ToString()
                                          }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in db.TblKitaplar.Where(y=>y.DURUM==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            List<SelectListItem> deger3 = (from x in db.TblPersoneller.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.AD + " " + x.SOYAD,
                                               Value = x.ID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            return View();
        }

        [HttpPost]
        public ActionResult oduncVer(TblHareketler x)
        {
            var deger1 =db.TblUyeler.Where(y=>y.ID==x.TblUyeler.ID).FirstOrDefault();
            var deger2 =db.TblKitaplar.Where(y=>y.ID==x.TblKitaplar.ID).FirstOrDefault();
            var deger3 =db.TblPersoneller.Where(y=>y.ID==x.TblPersoneller.ID).FirstOrDefault();
            x.TblUyeler = deger1;
            x.TblKitaplar = deger2;
            x.TblPersoneller = deger3;
            x.ISLEMDURUM = false;
            db.TblHareketler.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult oduncIade(TblHareketler x)
        {
            var odunc = db.TblHareketler.Find(x.ID);
            DateTime d1 =DateTime.Parse(odunc.IADETARIH.ToString());
            DateTime d2 =Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.deger = d3.TotalDays;
            return View("oduncIade", odunc);
        }

        public ActionResult oduncGuncelle(TblHareketler x)
        {
            var odunc = db.TblHareketler.Find(x.ID);
            odunc.UYETESLIMTARIH = x.UYETESLIMTARIH;
            odunc.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
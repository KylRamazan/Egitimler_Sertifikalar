using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        public ActionResult Index()
        {
            var deger1 = db.TblUyeler.Count();
            var deger2 = db.TblKitaplar.Count();
            var deger3 = db.TblKitaplar.Where(x=>x.DURUM==false).Count();
            var deger4 = db.TblCezalar.Sum(x=>x.UCRET);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();
        }

        public ActionResult Hava()
        {
            return View();
        }

        public ActionResult HavaKart()
        {
            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult resimYukle(HttpPostedFileBase dosya)
        {
            if(dosya.ContentLength > 0)
            {
                string dosyaYolu =  Path.Combine(Server.MapPath("~/web2/resimler/"),Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyaYolu);
            }
            return RedirectToAction("Galeri");
        }

        public ActionResult LinqKart()
        {
            var deger1 = db.TblKitaplar.Count();
            var deger2 = db.TblUyeler.Count();
            var deger3 = db.TblCezalar.Sum(x => x.UCRET);
            var deger4 = db.TblKitaplar.Where(x => x.DURUM == false).Count();
            var deger5 = db.TblKategoriler.Count();
            var deger8 =db.enFazlaKitapOlanYazar().FirstOrDefault();
            var deger9 =db.TblKitaplar.GroupBy(x=>x.YAYINEVI).OrderByDescending(z=>z.Count()).Select(y=>new { y.Key}).FirstOrDefault();
            var deger11 = db.TblIletisim.Count();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger5;
            ViewBag.dgr8 = deger8;
            ViewBag.dgr9 = deger9;
            ViewBag.dgr11 = deger11;
            return View();
        }
    }
}
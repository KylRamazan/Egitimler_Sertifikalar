using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        KutuphaneDBEntities db =new KutuphaneDBEntities();
        public ActionResult Index()
        {
            var degerler =db.TblDuyurular.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult yeniDuyuru()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yeniDuyuru(TblDuyurular x)
        {
            db.TblDuyurular.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult duyuruSil(int id)
        {
            var duyuru =db.TblDuyurular.Find(id);
            db.TblDuyurular.Remove(duyuru);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult duyuruDetay(TblDuyurular x)
        {
            var duyuru =db.TblDuyurular.Find(x.ID);
            return View("duyuruDetay",duyuru);
        }

        public ActionResult duyuruGuncelle(TblDuyurular x)
        {
            var duyuru = db.TblDuyurular.Find(x.ID);
            duyuru.KATEGORI = x.KATEGORI;
            duyuru.ICERIK = x.ICERIK;
            duyuru.TARIH = x.TARIH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcStokDBEntities db = new MvcStokDBEntities();
        [Authorize]
        public ActionResult Index(int sayfa=1)
        {
            var musteri = db.TblMusteriler.Where(x=>x.DURUM==true).ToList().ToPagedList(sayfa,5);
            return View(musteri);
        }

        [HttpGet]
        [Authorize]
        public ActionResult yeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yeniMusteri(TblMusteriler musteri)
        {
            if(!ModelState.IsValid)
            {
                return View("yeniMusteri");
            }
            musteri.DURUM = true;
            db.TblMusteriler.Add(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult musteriSil(TblMusteriler musteri)
        {
            var musteriBul = db.TblMusteriler.Find(musteri.ID);
            musteriBul.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult musteriGetir(int id)
        {
            var musteri = db.TblMusteriler.Find(id);
            return View("musteriGetir", musteri);
        }

        [Authorize]
        public ActionResult musteriGuncelle(TblMusteriler musteri)
        {
            var mstri = db.TblMusteriler.Find(musteri.ID);
            mstri.AD = musteri.AD;
            mstri.SOYAD = musteri.SOYAD;
            mstri.SEHIR = musteri.SEHIR;
            mstri.BAKIYE = musteri.BAKIYE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
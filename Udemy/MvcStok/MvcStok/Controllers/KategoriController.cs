using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcStokDBEntities db = new MvcStokDBEntities();
        [Authorize]
        public ActionResult Index()
        {
            var kategoriler = db.TblKategoriler.ToList();
            return View(kategoriler);
        }

        [HttpGet]
        [Authorize]
        public ActionResult yeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yeniKategori(TblKategoriler kategori)
        {
            db.TblKategoriler.Add(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult kategoriSil(int id)
        {
            var kategori = db.TblKategoriler.Find(id);
            db.TblKategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult kategoriGetir(int id)
        {
            var kategori = db.TblKategoriler.Find(id);
            return View("kategoriGetir",kategori);
        }

        [Authorize]
        public ActionResult kategoriGuncelle(TblKategoriler kategori)
        {
            var ktgr = db.TblKategoriler.Find(kategori.ID);
            ktgr.AD = kategori.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
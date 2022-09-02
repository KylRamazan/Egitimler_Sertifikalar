using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        public ActionResult Index()
        {
            var degerler = db.TblPersoneller.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult personelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult personelEkle(TblPersoneller x)
        {
            if(!ModelState.IsValid)
            {
                return View("personelEkle");
            }
            db.TblPersoneller.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult personelSil(int id)
        {
            var personel = db.TblPersoneller.Find(id);
            db.TblPersoneller.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult personelGetir(int id)
        {
            var personel = db.TblPersoneller.Find(id);
            return View("personelGetir", personel);
        }

        public ActionResult personelGuncelle(TblPersoneller x)
        {
            if (!ModelState.IsValid)
            {
                return View("personelGetir");
            }
            var personel = db.TblPersoneller.Find(x.ID);
            personel.AD = x.AD;
            personel.SOYAD = x.SOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
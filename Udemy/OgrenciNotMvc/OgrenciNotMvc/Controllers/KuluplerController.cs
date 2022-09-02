using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        MvcOkulDBEntities db = new MvcOkulDBEntities();
        public ActionResult Index()
        {
            var kulupler = db.TblKulupler.ToList();
            return View(kulupler);
        }

        [HttpGet]
        public ActionResult yeniKulup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yeniKulup(TblKulupler kulup)
        {
            db.TblKulupler.Add(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult kulupSil(int id)
        {
            var kulup =db.TblKulupler.Find(id);
            db.TblKulupler.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult kulupGuncelle(TblKulupler klp)
        {
            var kulup = db.TblKulupler.Find(klp.KULUPID);
            kulup.KULUPAD = klp.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult kulupGetir(int id)
        {
            var kulup =db.TblKulupler.Find(id);
            return View("kulupGetir",kulup);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;

namespace OgrenciNotMvc.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        MvcOkulDBEntities db = new MvcOkulDBEntities();
        public ActionResult Index()
        {
            var dersler =db.TblDersler.ToList();
            return View(dersler);
        }

        [HttpGet]
        public ActionResult yeniDers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yeniDers(TblDersler ders)
        {
            db.TblDersler.Add(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult dersSil(int id)
        {
            var ders = db.TblDersler.Find(id);
            db.TblDersler.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult dersGuncelle(TblDersler drs)
        {
            var ders = db.TblDersler.Find(drs.DERSID);
            ders.DERSAD = drs.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult dersGetir(int id)
        {
            var ders = db.TblDersler.Find(id);
            return View("dersGetir",ders);
        }
    }
}
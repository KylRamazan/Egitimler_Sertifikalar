using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
using OgrenciNotMvc.Models;

namespace OgrenciNotMvc.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Notlar
        MvcOkulDBEntities db = new MvcOkulDBEntities();
        public ActionResult Index()
        {
            var notlar = db.TblNotlar.ToList();
            return View(notlar);
        }

        [HttpGet]
        public ActionResult yeniNot()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yeniNot(TblNotlar not)
        {
            db.TblNotlar.Add(not);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult notGetir(int id)
        {
            var not = db.TblNotlar.Find(id);
            return View("notGetir", not);
        }

        [HttpPost]
        public ActionResult notGetir(Class1 model,TblNotlar not,int sinav1,int sinav2,int sinav3,int proje)
        {
            if(model.islem=="Hesapla")
            {
                int ortalama =(sinav1 + sinav2 + sinav3 + proje) / 4;
                ViewBag.ort = ortalama;

            }else if(model.islem == "NotGuncelle")
            {
                var sinavNot =db.TblNotlar.Find(not.NOTID);
                sinavNot.SINAV1 = not.SINAV1;
                sinavNot.SINAV2 = not.SINAV2;
                sinavNot.SINAV3 = not.SINAV3;
                sinavNot.PROJE = not.PROJE;
                sinavNot.ORTALAMA = not.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
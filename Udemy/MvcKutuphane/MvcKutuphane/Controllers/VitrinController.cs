using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.Siniflarim;

namespace MvcKutuphane.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.deger1 = db.TblKitaplar.ToList();
            cs.deger2 = db.TblHakkimizda.ToList();
            return View(cs);
        }

        [HttpPost]
        public ActionResult Index(TblIletisim x)
        {
            db.TblIletisim.Add(x);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
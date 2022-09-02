using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KayitController : Controller
    {
        // GET: Kayit
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KayitOl(TblUyeler x)
        {
            if(!ModelState.IsValid)
            {
                return View("KayitOl");
            }
            db.TblUyeler.Add(x);
            db.SaveChanges();
            return View();
        }
    }
}
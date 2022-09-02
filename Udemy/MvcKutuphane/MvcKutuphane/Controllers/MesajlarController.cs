using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        public ActionResult Index()
        {
            var uyeBilgi =(string)Session["KullaniciAdi"].ToString();
            var uyeMail =db.TblUyeler.FirstOrDefault(y=>y.KULLANICIADI==uyeBilgi);
            var mesajlar = db.TblMesajlar.Where(x=>x.ALICI==uyeMail.MAIL.ToString()).ToList();
            return View(mesajlar);
        }

        public ActionResult GidenMesaj()
        {
            var uyeBilgi = (string)Session["KullaniciAdi"].ToString();
            var uyeMail = db.TblUyeler.FirstOrDefault(y => y.KULLANICIADI == uyeBilgi);
            var mesajlar = db.TblMesajlar.Where(x => x.GONDEREN == uyeMail.MAIL.ToString()).ToList();
            return View(mesajlar);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(TblMesajlar p)
        {
            var uyeBilgi = (string)Session["KullaniciAdi"].ToString();
            var uyeMail = db.TblUyeler.FirstOrDefault(y => y.KULLANICIADI == uyeBilgi);
            p.GONDEREN =uyeMail.MAIL.ToString();
            p.TARIH =DateTime.Now;
            db.TblMesajlar.Add(p);
            db.SaveChanges();
            return RedirectToAction("GidenMesaj","Mesajlar");
        }
    }
}
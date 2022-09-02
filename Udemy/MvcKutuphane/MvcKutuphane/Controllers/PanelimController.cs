using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class PanelimController : Controller
    {
        // GET: Panelim
        KutuphaneDBEntities db = new KutuphaneDBEntities();

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var uyeKullaniciAdi =(string)Session["KullaniciAdi"];
            var degerler =db.TblUyeler.FirstOrDefault(x=>x.KULLANICIADI==uyeKullaniciAdi);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult Index2(TblUyeler p)
        {
            var kullanici = (string)Session["KullaniciAdi"];
            var uye =db.TblUyeler.FirstOrDefault(x=>x.KULLANICIADI==kullanici);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAIL = p.MAIL;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.SIFRE =p.SIFRE;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.TELEFON = p.TELEFON;
            uye.OKUL = p.OKUL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["KullaniciAdi"];
            var id =db.TblUyeler.Where(x=>x.KULLANICIADI==kullanici.ToString()).Select(y=>y.ID).FirstOrDefault();
            var degerler =db.TblHareketler.Where(x=>x.UYE==id).ToList();
            return View(degerler);
        }

        public ActionResult Duyurular()
        {
            var degerler = db.TblDuyurular.ToList();
            return View(degerler);
        }

        public ActionResult logOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("girisYap","Login");
        }
    }
}
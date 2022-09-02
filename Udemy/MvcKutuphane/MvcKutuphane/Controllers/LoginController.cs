using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        KutuphaneDBEntities db = new KutuphaneDBEntities();

        [HttpGet]
        public ActionResult girisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult girisYap(TblUyeler p)
        {
            var bilgiler = db.TblUyeler.FirstOrDefault(x => x.KULLANICIADI == p.KULLANICIADI && x.SIFRE == p.SIFRE);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANICIADI,false);
                Session["KullaniciAdi"]=bilgiler.KULLANICIADI.ToString();
                //TempData["Id"] = bilgiler.ID.ToString();
                //TempData["Ad"]=bilgiler.AD.ToString();
                //TempData["Soyad"]=bilgiler.SOYAD.ToString();
                //TempData["Mail"]=bilgiler.MAIL.ToString();
                //TempData["Sifre"]=bilgiler.SIFRE.ToString();
                //TempData["Okul"]=bilgiler.OKUL.ToString();
                return RedirectToAction("Index","Panelim");
            }
            else
            {
                return View();
            }
        }
    }
}
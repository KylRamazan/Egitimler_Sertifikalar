using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        MvcStokDBEntities db = new MvcStokDBEntities();
        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(TblAdmin admin)
        {
            var bilgiler =db.TblAdmin.FirstOrDefault(x=>x.KULLANICI==admin.KULLANICI && x.SIFRE==admin.SIFRE);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KULLANICI,false);
                return RedirectToAction("Index","Urun");
            }
            else
            {
                return View();
            }
        }
    }
}
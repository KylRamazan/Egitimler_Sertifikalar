using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class IslemController : Controller
    {
        // GET: Islem
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHareketler.Where(x => x.ISLEMDURUM == true).ToList();
            return View(degerler);
        }
    }
}
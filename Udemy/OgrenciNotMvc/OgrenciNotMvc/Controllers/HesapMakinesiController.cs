using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciNotMvc.Controllers
{
    public class HesapMakinesiController : Controller
    {
        // GET: HesapMakinesi
        public ActionResult Index(int sayi=0,int sayi2=0)
        {
            double toplamaSonuc = sayi + sayi2;
            double cikarmaSonuc = sayi - sayi2;
            double carpmaSonuc = sayi * sayi2;
            double bolmeSonuc = (double)sayi / (double)sayi2;
            ViewBag.snc =toplamaSonuc;
            ViewBag.snc2 =cikarmaSonuc;
            ViewBag.snc3 =carpmaSonuc;
            ViewBag.snc4 =bolmeSonuc;
            return View();
        }
    }
}
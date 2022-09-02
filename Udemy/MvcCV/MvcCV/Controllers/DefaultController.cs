using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Models.Sinif;

namespace MvcCV.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        MvcCVSitesiDBEntities db = new MvcCVSitesiDBEntities();
        public ActionResult Index()
        {
            //var degerler = db.TblAbout.ToList();
            Class1 cs = new Class1();
            cs.deger1 = db.TblAbout.ToList();
            cs.deger2 = db.TblExperience.ToList();
            cs.deger3 = db.TblEducation.ToList();
            cs.deger4 = db.TblSkills.ToList();
            cs.deger5 = db.TblInterests.ToList();
            cs.deger6 = db.TblAwards.ToList();
            return View(cs);
        }
    }
}
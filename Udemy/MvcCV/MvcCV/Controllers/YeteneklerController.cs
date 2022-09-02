using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Models.Sinif;
using PagedList.Mvc;
using PagedList;

namespace MvcCV.Controllers
{
    public class YeteneklerController : Controller
    {
        // GET: Yetenekler
        MvcCVSitesiDBEntities db = new MvcCVSitesiDBEntities();
        public ActionResult Index(int sayfa=1)
        {
            var yetenek= db.TblSkills.ToList().ToPagedList(sayfa,3);
            return View(yetenek);
        }

        [HttpGet]
        public ActionResult yeniYetenek()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yeniYetenek(TblSkills yetenek)
        {
            db.TblSkills.Add(yetenek);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult yetenekSil(int id)
        {
            var yetenek = db.TblSkills.Find(id);
            db.TblSkills.Remove(yetenek);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult yetenekGetir(int id)
        {
            var yetenek = db.TblSkills.Find(id);
            return View("yetenekGetir", yetenek);
        }

        public ActionResult yetenekGuncelle(TblSkills x)
        {
            var yetenek = db.TblSkills.Find(x.ID);
            yetenek.SKILL = x.SKILL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
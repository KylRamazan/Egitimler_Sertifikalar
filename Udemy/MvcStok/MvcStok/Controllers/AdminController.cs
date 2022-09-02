using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        MvcStokDBEntities db = new MvcStokDBEntities();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult yeniAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult yeniAdmin(TblAdmin admin)
        {
            db.TblAdmin.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
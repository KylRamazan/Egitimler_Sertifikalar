﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class GirisController : Controller
    {
        // GET: Giris
        public ActionResult Login()
        {
            return View();
        }
    }
}
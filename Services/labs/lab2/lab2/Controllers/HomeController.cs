﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return File("~/Views/Home/Index.html", "text/html");
        }
    }
}

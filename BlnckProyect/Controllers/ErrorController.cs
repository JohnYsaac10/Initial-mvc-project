﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlnckProyect.Controllers
{
    public class ErrorController : Controller
    {
 
        public ActionResult DetalleError(int id)
        {
            return View(id);
        }
    }
}
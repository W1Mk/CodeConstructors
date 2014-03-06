using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projecten.Controllers
{
    public class BedrijfController : Controller
    {
        //
        // GET: /Bedrijf/

        public ActionResult Index()
        {
            ViewBag.Message = "index";
            return View();
        }

    }
}

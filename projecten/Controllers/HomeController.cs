
using projecten.Models.DAL;
using projecten.Models.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace projecten.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Index";
          
            
            BedrijfContext context = new BedrijfContext();
           
            BedrijfRepository rep = new BedrijfRepository(context);
            Bedrijf bedrijf = new Bedrijf();
            rep.Add(bedrijf);
           
            rep.FindBy("ikke");

           
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "over";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "contact";

            return View();
        }
      
    }
}

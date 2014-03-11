using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using projecten.Models.DAL;
using projecten.Models.Domain;

namespace projecten.Controllers
{
    public class BedrijfController : Controller
    {
        private BedrijfRepository bedrijfRepository;
        //
        // GET: /Bedrijf/

        public BedrijfController(BedrijfRepository bedrijfRepository)
        {
            this.bedrijfRepository = bedrijfRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "testing";
            //  IEnumerable<Bedrijf> bedrijven = bedrijfR
            return View("Index");
        }

       /* public ActionResult Create()
        {
            return View();
        }*/

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using projecten.Models;
using projecten.Models.DAL;
using projecten.Models.Domain;

namespace projecten.Controllers
{
    public class BedrijfController : Controller
    {
        private BedrijfRepository bedrijfRepository;
        private StageOpdrachtRepository stageOpdrachtRepository;
        //
        // GET: /Bedrijf/

        public BedrijfController(BedrijfRepository bedrijfRepository, StageOpdrachtRepository stageOpdrachtRepository)
        {
            this.bedrijfRepository = bedrijfRepository;
            this.stageOpdrachtRepository = stageOpdrachtRepository;
        }

        public BedrijfController()
        {
            
        }

        public ActionResult Index()
        {
            ViewBag.Message = "testing";
            //  IEnumerable<Bedrijf> bedrijven = bedrijfR
            return View("Index");
        }

        public ActionResult StageOpdrachten()
        {
           // IEnumerable<StageOpdracht> stageOpdrachten =  stageOpdrachtRepository.FindAll().OrderBy(b => b.Naam).ToList();
            return View();
        }

        
        [AllowAnonymous]
        public ActionResult StageOpdrachtToevoegen(StageOpdrachtToevoegenModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return RedirectToAction("StageOpdrachten", "Bedrijf");
                }
                catch (MembershipCreateUserException e)
                {
                    throw new MembershipCreateUserException();
                }
            }
            return View();
            return RedirectToAction("StageOpdrachten", "Bedrijf");
        }
       /* public ActionResult Create()
        {
            return View();
        }*/

    }
}

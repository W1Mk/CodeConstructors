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
      private static  projecten.Models.DAL.BedrijfContext context = new projecten.Models.DAL.BedrijfContext();
      private BedrijfRepository BedrijfRep = new BedrijfRepository(context);
      private StudentRepository StudentRep = new StudentRepository(context);
      private StageOpdrachtRepository StageRep = new StageOpdrachtRepository(context);
      private string username;
      private AccountController controller;
        //
        // GET: /Bedrijf/

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
            username = controller.username;
            
            if (ModelState.IsValid)
            {
                try
                {
                StageOpdracht opdracht = new StageOpdracht
                {
                    Naam = model.StageNaam,
                    Semester = model.Semester,
                    Omschrijving = model.Omschrijving,
                    Specialisatie = model.Specialisatie,
                    AantalStudenten = model.Aantal,
                    StageMentor = model.StageMentor,
                    Status = "wachten"

                };
                opdracht.Bedrijf.BedrijfId = BedrijfRep.FindId(username);
                StageRep.Add(opdracht);
                StageRep.SaveChanges();
                return RedirectToAction("StageOpdrachten", "Bedrijf");
                }  catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", e.StatusCode.ToString());
                }
            }

            return View();
        }
            
            
        }
       /* public ActionResult Create()
        {
            return View();
        }*/

    }


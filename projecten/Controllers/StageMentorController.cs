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
    public class StageMentorController : Controller
    {
        private static projecten.Models.DAL.BedrijfContext context = new projecten.Models.DAL.BedrijfContext();
        private StageMentorRepository MentorRep = new StageMentorRepository(context);

        [AllowAnonymous]
        public ActionResult ProfielMentor(int id)
        {
            StageMentor mentor = MentorRep.FindBy(id);
            var viewmodel = new StageMentorModel(mentor);
           
            return View(viewmodel);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult ProfielMentor(int id, StageMentorModel model)
        {
            StageMentor mentor = MentorRep.FindBy(id);
            var viewmodel = new StageMentorModel(mentor);
            if (ModelState.IsValid)
            {
                try
                {
                    return RedirectToAction("ProfielWijzigen", new { id = id });
                    //return View("ProfielWijzigigen", new { id = id });
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", e.StatusCode.ToString());
                }
            }
           // return RedirectToAction("ProfielWijzigen", new { id = id });
            return View(viewmodel);

        }
        [AllowAnonymous]
        public ActionResult ProfielWijzigen(int id)
        {
            StageMentor mentor = MentorRep.FindBy(id);
            var viewmodel = new StageMentorModel(mentor);
            return View(viewmodel);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult ProfielWijzigen(int id, StageMentorModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    StageMentor mentor1 = MentorRep.FindBy(id);
                    mentor1.setUpdates(model);
                    MentorRep.SaveChanges();
                    return RedirectToAction("ProfielMentor", new { id = id });
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", e.StatusCode.ToString());
                }

            }
            StageMentor mentor = MentorRep.FindBy(id);
            var viewmodel = new StageMentorModel(mentor);

            return View(viewmodel);
        }
    }
}
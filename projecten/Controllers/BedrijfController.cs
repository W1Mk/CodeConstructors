using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using projecten.Models;
using projecten.Models.DAL;
using projecten.Models.Domain;
using System.Net.Mail;
using System.Net;

namespace projecten.Controllers
{
    public class BedrijfController : Controller
    {
        private static projecten.Models.DAL.BedrijfContext context = new projecten.Models.DAL.BedrijfContext();
        private BedrijfRepository BedrijfRep = new BedrijfRepository(context);
        private StudentRepository StudentRep = new StudentRepository(context);
        private StageOpdrachtRepository StageRep = new StageOpdrachtRepository(context);
        private StageMentorRepository MentorRep = new StageMentorRepository(context);

        public ActionResult StageOpdrachten()
        {
            IEnumerable<StageOpdracht> lijst = BedrijfRep.FindBy(User.Identity.Name).stages;
             return View(lijst);
        }
        [AllowAnonymous]
        public ActionResult StageOpdrachtToevoegen()
        {         
            return View();
        }
    
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult StageOpdrachtToevoegen(StageOpdrachtToevoegenModel model)
        {
            StageOpdracht opdracht = new StageOpdracht(model);
            if (ModelState.IsValid)
            {
                try
                {
                    string subject = "Toegevoegde opdracht";
                    string body = "Beste," + "\r\n\r\n" + "De opdracht werd succesvol toegevoegd." + "\r\n" +
                                  "U kan deze bekijken, verwijderen en wijzigen op onze site." +
                                  "\r\n\r\n" + "Vriendelijke groeten," + "\r\n" + "Het InternNet-Team.";

                    if (BedrijfRep.FindBy((User.Identity.Name)) != null)
                    {
                        Bedrijf bedrijf = BedrijfRep.FindBy(User.Identity.Name);
                        
                        bedrijf.AddStageOpdracht(opdracht);
                    }
                    BedrijfRep.SaveChanges();
                    StageRep.SaveChanges();

                    sendMail(User.Identity.Name, subject, body);

                    return RedirectToAction("StageOpdrachten", "Bedrijf");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", e.StatusCode.ToString());
                }
            }

            return View(model);
        }
        public void sendMail(string to, string subject, string body)
        {
            MailMessage message = new MailMessage();
            message.To.Add(to);
            message.Subject = subject;
            message.Body = body;
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("nielsdepauw94@gmail.com", " qsraqfdnmtbefoih "),
                EnableSsl = true

            };
            client.Send("nielsdepauw94@gmail.com", message.To.ToString(), message.Subject, message.Body);
        }
        [AllowAnonymous]
        public ActionResult StageOpdrachtWijzigen(int id)
        {
            if (StageRep.FindBy(id) != null)
            {
                StageOpdracht opdracht = StageRep.FindBy(id);
                StageOpdrachtToevoegenModel model = new StageOpdrachtToevoegenModel(opdracht);
                
                return View(model);
            }
            return View(new StageOpdrachtToevoegenModel());
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult StageOpdrachtWijzigen(int id, StageOpdrachtToevoegenModel stage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string subject = "Gewijzigde opdracht";
                    string body = "Beste," + "\r\n\r\n" + "Uw wijzigingen aan de opdracht zijn succesvol doorgevoerd." + "\r\n" +
                                  "U kan deze bekijken, verwijderen en wijzigen op onze site." +
                                  "\r\n\r\n" + "Vriendelijke groeten," + "\r\n" + "Het InternNet-Team.";
                    if (StageRep.FindBy(id) != null)
                    {
                        StageOpdracht opdrachtupdate = StageRep.FindBy(id);
                        opdrachtupdate.setUpdates(stage);
                    }
                    StageRep.SaveChanges();
                    sendMail(User.Identity.Name, subject, body);
                    return RedirectToAction("StageOpdrachten", "Bedrijf");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", e.StatusCode.ToString());
                }
            }
            if (StageRep.FindBy(id) != null)
            {
                StageOpdracht opdracht = StageRep.FindBy(id);
                StageOpdrachtToevoegenModel model = new StageOpdrachtToevoegenModel(opdracht);
                
                return View(model);
            }
            return View(new StageOpdrachtToevoegenModel());
        }

        [AllowAnonymous]
        public ActionResult Delete(int id)
        {
            if (StageRep.FindBy(id) != null)
            {
                StageOpdracht stage = StageRep.FindBy(id);
                return View(stage);
            }
            return View(new StageOpdracht());
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Delete(int id,StageOpdracht stage)
        {
            //StageOpdracht opdracht = StageRep.FindBy(id);
            if (ModelState.IsValid)
            {
                string subject = "Verwijderde opdracht";
                string body = "Beste," + "\r\n\r\n" + "De opdracht met naam " + stage.Naam + " is succesvol verwijderd" + "\r\n" +
                              "\r\n\r\n" + "Vriendelijke groeten," + "\r\n" + "Het InternNet-Team.";
                //stage = StageRep.FindBy(id);
                if (BedrijfRep.FindBy(User.Identity.Name) != null)
                {
                    Bedrijf bedrijf = BedrijfRep.FindBy(User.Identity.Name);
                    StageRep.Delete(bedrijf.DeleteStageOpdracht(id));
                }
                BedrijfRep.SaveChanges();
                StageRep.SaveChanges();
                sendMail(User.Identity.Name, subject, body);
                return RedirectToAction("StageOpdrachten");
            }
            /*var viewmodel = new DeleteOpdracht();
            viewmodel.Naam = opdracht.Naam;*/
            return View(stage);
        }
        [AllowAnonymous]
        public ActionResult StageMentoren()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult StageMentorToevoegen()
        {
            return View(new StageMentorModel());
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult StageMentorToevoegen(StageMentorModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string subject = "Toegevoegde stagementor";
                    string body = "";
                    if (BedrijfRep.FindBy(User.Identity.Name) != null)
                    {
                        Bedrijf bedrijf = BedrijfRep.FindBy(User.Identity.Name);
                        StageMentor mentor = new StageMentor(model);
                        bedrijf.AddStageMentor(mentor);
                        body = "Beste," + "\r\n\r\n" + "Er is een niewe stagementor toegevoegd bij bedrijf "
                                   + bedrijf.Bedrijfsnaam +"."+ "\r\n" + "Deze heeft als naam " + mentor.Naam + "." +
                                  "\r\n\r\n" + "Vriendelijke groeten," + "\r\n" + "Het InternNet-Team.";
                    }
                    BedrijfRep.SaveChanges();
                    MentorRep.SaveChanges();
                    sendMail("depauwniels@hotmail.com", subject, body);
                    return RedirectToAction("StageMentoren", "Bedrijf");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", e.StatusCode.ToString());
                }
            }
            return View(model);
        }

        public ActionResult ProfielMentor(int id)
        {
            return RedirectToAction("ProfielMentor", "StageMentor", new { id = id });
        }

        [AllowAnonymous]
        public ActionResult DeleteMentor(int id)
        {
            if (MentorRep.FindBy(id) != null)
            {
                StageMentor mentor = MentorRep.FindBy(id);
                return View(mentor);
            }
            return View(new StageMentor());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult DeleteMentor(int id, StageMentor mentor)
        {
            if (ModelState.IsValid)
            {
                string subject = "Verwijderde stagementor";
                string body = "";
                //mentor = MentorRep.FindBy(id);
                if (BedrijfRep.FindBy(User.Identity.Name) != null)
                {
                    Bedrijf bedrijf = BedrijfRep.FindBy(User.Identity.Name);
                    MentorRep.Delete(bedrijf.DeleteStageMentor(id));
                    body = "Beste," + "\r\n\r\n" + "Bedrijf "
                                   + bedrijf.Bedrijfsnaam + " heeft stagementor "+ mentor.Naam + " verwijderd." + "\r\n" +
                                  "\r\n\r\n" + "Vriendelijke groeten," + "\r\n" + "Het InternNet-Team.";
                }
                BedrijfRep.SaveChanges();
                MentorRep.SaveChanges();
                sendMail("depauwniels@hotmail.com", subject, body);
                return RedirectToAction("StageMentoren");
            }
            return View(mentor);
        }
        /* public ActionResult Create()
         {
             return View();
         }*/

    }
}

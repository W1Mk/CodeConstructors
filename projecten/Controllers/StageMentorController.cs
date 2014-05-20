using System.Net;
using System.Net.Mail;
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
        private BedrijfRepository bedrep = new BedrijfRepository(context);

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
            model = new StageMentorModel(mentor);
            if (ModelState.IsValid)
            {
                try
                {
                    return RedirectToAction("ProfielWijzigen", new { id = id });
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", e.StatusCode.ToString());
                }
            }
            return View(model);

        }
        [AllowAnonymous]
        public ActionResult ProfielWijzigen(int id)
        {
            StageMentor mentor = MentorRep.FindBy(id);
            var viewmodel = new StageMentorWijzigenModel(mentor);
            return View(viewmodel);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult ProfielWijzigen(int id, StageMentorWijzigenModel model)
        {
            if (ModelState.IsValid)
            {
                string subject = "Wijziging stagementor";
                string body = "Beste," + "\r\n\r\n" + "Bedrijf "
                                   + bedrep.FindBy(User.Identity.Name).Bedrijfsnaam + " heeft stagementor "+ model.Naam + " aangepast." + "\r\n" +
                                  "\r\n\r\n" + "Vriendelijke groeten," + "\r\n" + "Het InternNet-Team.";
                try
                {
                    StageMentor mentor1 = MentorRep.FindBy(id);
                    mentor1.setUpdates(model);
                    MentorRep.SaveChanges();
                    sendMail(User.Identity.Name, subject, body);
                    return RedirectToAction("ProfielMentor", new { id = id });
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", e.StatusCode.ToString());
                }

            }
            StageMentor mentor = MentorRep.FindBy(id);
            var viewmodel = new StageMentorWijzigenModel(mentor);

            return View(viewmodel);
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
    }
}
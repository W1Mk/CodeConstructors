
using System.Net;
using System.Net.Mail;
using projecten.Models;
using projecten.Models.DAL;
using projecten.Models.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Windows.Forms;

namespace projecten.Controllers
{
    public class HomeController : Controller
    {
        static BedrijfContext context = new BedrijfContext();
        public BedrijfRepository BedrijfRep = new BedrijfRepository(context);
        public ActionResult Index()
        {
            ViewBag.Message = "Index";

           
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

        public ActionResult ProjectenI()
        {
            return View();
        }
        public ActionResult ProjectenII()
        {
            return View();
        }
        public ActionResult ProjectenIII()
        {
            return View();
        }
        public ActionResult Stage()
        {
            return View();
        }
        public ActionResult Bachelorproef()
        {
            return View();
        }
        public ActionResult Bedrijven()
        {
            var bedrijven = BedrijfRep.FindAll();
            foreach (var item in bedrijven)
            {
                var foto = (Byte[])item.Foto;
                if (foto != null)
                {
                    item.FotoString = Convert.ToBase64String(item.Foto);
                }
            }
            
            return View(bedrijven);
        }

        [HttpPost]
        public ActionResult Bedrijven(string zoekopdracht)
        {
            var bedrijven = BedrijfRep.FindAllFilter(zoekopdracht);
            return View(bedrijven);
        }

        public ActionResult ContactBachelor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactBachelor(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string subject = "Contact Bachelorproef " + model.Naam;
                    string body = "Beste," + "\r\n\r\n" + "Student " + model.Naam + " " + model.Voornaam
                                  + " had een vraag/opmerking over de bachelorproef van " + model.Bedrijf +
                                  " met als omschrijving: " + "\r\n\r\n" + model.Omschrijving + "\r\n\r\n" +
                                  " Zijn/Haar vraag/opmerking was:" + "\r\n\r\n" + model.Vragen + "\r\n\r\n"
                                  + "Vriendelijke groeten," + "\r\n" + "Het InternNet-Team.";
                    sendMail("depauwniels@hotmail.com",subject,body);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    
                    throw;
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
    }
}

using MySql.Data.MySqlClient;
using projecten.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projecten.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
     

        public ActionResult Index()
        {
            return View();
        }
         [AllowAnonymous]
        public ActionResult Profiel()
        {
            return View();
        }
         [HttpPost]
         [AllowAnonymous]
        
         public ActionResult Profiel(ProfielModel model)
         {
             return RedirectToAction("Index", "Student");
         }
        [AllowAnonymous]
        public ActionResult ProfielWachtwoord()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
       
        public ActionResult ProfielWachtwoord(ProfielModel model)
        {
            return RedirectToAction("Index", "Student");
        }
        
        
    }
}

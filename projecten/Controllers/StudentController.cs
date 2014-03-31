using MySql.Data.MySqlClient;
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
     

      /*  public ActionResult Index()
        {
            return View();
        }*/
        public ActionResult Profiel()
        {
           
     
            return View();
        }
    }
}

using projecten.Models;
using projecten.Models.DAL;
using projecten.Models.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projecten.Controllers

{
    [Authorize]
    public class StudentController : Controller
    {
        static BedrijfContext context = new BedrijfContext();
        StudentRepository studentRep = new StudentRepository(context);
        StageOpdrachtRepository stageRep = new StageOpdrachtRepository(context);
        StageBegeleiderRepository begrep = new StageBegeleiderRepository(context);
        
         [AllowAnonymous]
        public ActionResult Profiel()
        {
            Student student = studentRep.FindBy(User.Identity.Name);
            ProfielModel ProfielModel = new ProfielModel(student);
            try
            {
                var foto = (Byte[])student.Foto;
                if(foto != null)
                ProfielModel.Foto= Convert.ToBase64String(foto);
                else
                {
                    foto = new byte[20];
                    ProfielModel.Foto = Convert.ToBase64String(foto);
                }
                ProfielModel.OudWachtwoord = student.Wachtwoord;
                if (ProfielModel.Adres == null)
                {
                    ProfielModel.Adres = "/";
                }
                if (ProfielModel.Gsm == null)
                {
                    ProfielModel.Gsm = "/";
                }
                if (ProfielModel.Keuzevak == null)
                {
                    ProfielModel.Keuzevak = "/";
                }
                if (ProfielModel.Naam == null)
                {
                    ProfielModel.Naam = "/";
                }
                if (ProfielModel.TweedeEmail == null)
                {
                    ProfielModel.TweedeEmail = "/";
                }
               
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
           
            return View(ProfielModel);
        }
         
         [HttpPost]
         [AllowAnonymous]
        
         public ActionResult Profiel(ProfielModel model,HttpPostedFileBase image)
         {
             Student student = studentRep.FindBy(User.Identity.Name);
             MemoryStream target = new MemoryStream();
             byte[] arr = target.ToArray();
             if (image != null)
             {
                 
                 image.InputStream.CopyTo(target);
               
                 arr = target.ToArray();
                 student.Foto = arr;
                 model.Foto = Convert.ToBase64String(arr);
             }
            
             var data = (Byte[])student.Foto;
             student.setUpdates(model);
             studentRep.SaveChanges();
             target.Close();
             return View(model);
         }
           [AllowAnonymous]
           public ActionResult Stages()
         {           
             var stages = stageRep.FindAll();
             return View(stages);
         }
           [AllowAnonymous]
           [HttpPost]
           public ActionResult Stages(string zoekopdracht)
           {
                    var stages = stageRep.FindAllBy(zoekopdracht);
                    return View(stages); 
           }
           [AllowAnonymous]
           public ActionResult IngenomenStages()
           {
               Student student = studentRep.FindBy(User.Identity.Name);

               var stages = student.getStageOpdrachten();
               
               return View(stages);
           }
           [AllowAnonymous]
           [HttpPost]
           public ActionResult IngenomenStages(StagesModel model)
           {
               return View();
           }
           [AllowAnonymous]

           public ActionResult Bekijk(StagesModel model,int id)
           {
               StageOpdracht stage = stageRep.FindBy(id);
               return View(stage);
           }
           [AllowAnonymous]
           [HttpPost]
           public ActionResult Bekijk(int id)
           {
               StageOpdracht stage = stageRep.FindBy(id);
               Student student = studentRep.FindBy(User.Identity.Name);
               AcademieJaar jaar = new AcademieJaar();
               if (stage.AantalStudenten == 0)
               {
                   
               }
               else
               {
                   StageBegeleider beg = new StageBegeleider();
                   if (student.Stageopdrachten.Any())
                   {
                       ICollection<StageOpdracht> lijst = student.Stageopdrachten.ToList();
                       if (!lijst.Where(b => b.Academiejaar == stage.Academiejaar).Any())
                       {
                           beg.VoegOpdrachtAanBegeleidersToe(begrep.GetBegeleiders(), stage);
                           student.AddStageOpdracht(stage);
                           if (stage.Semester == "1")
                           {
                               student.BeginDatum = new DateTime(2013, 09, 01);
                               student.EindeDatum = new DateTime(2013, 12, 20);
                           }
                           else if (stage.Semester == "2")
                           {
                               student.BeginDatum = new DateTime(2014, 01, 01);
                               student.EindeDatum = new DateTime(2014, 06, 30);
                           }
                           else
                           {
                               student.BeginDatum = new DateTime(2013, 09, 01);
                               student.EindeDatum = new DateTime(2014, 12, 20);
                           }
                           stage.AantalStudenten -= 1;
                       }
                       else
                       {
                           ModelState.AddModelError("CustomError","Je kan maar 1 opdracht per acadamiejaar innemen.");
                           return View(stage);
                       }
                   }
                   else
                   {
                       if (stage.Semester == "1")
                       {
                           student.BeginDatum = new DateTime(2013, 09, 01);
                           student.EindeDatum = new DateTime(2013, 12, 20);
                       }
                       else if (stage.Semester == "2")
                       {
                           student.BeginDatum = new DateTime(2014, 01, 01);
                           student.EindeDatum = new DateTime(2014, 06, 30);
                       }
                       else
                       {
                           student.BeginDatum = new DateTime(2013, 09, 01);
                           student.EindeDatum = new DateTime(2014, 12, 20);
                       }
                       beg.VoegOpdrachtAanBegeleidersToe(begrep.GetBegeleiders(), stage);
                       student.AddStageOpdracht(stage);
                       stage.AantalStudenten -= 1;
                   }
                   
               }
               stageRep.Update(stage);
               stageRep.SaveChanges();
               return RedirectToAction("IngenomenStages","Student");
           }

        public ActionResult Solicitatie(int id)
        {
            StageOpdracht stage = stageRep.FindBy(id);
            return View(stage);
        }

        [HttpPost]
        public ActionResult Solicitatie(int id, StageOpdracht stage)
        {
            if (ModelState.IsValid)
            {
                Student student = studentRep.FindBy(User.Identity.Name);
                stage = stageRep.FindBy(id);
                
                student.Soliciteer(stage);
                studentRep.SaveChanges();
                return RedirectToAction("Stages");
            }
            return View(stage);
        }
        
    }
}

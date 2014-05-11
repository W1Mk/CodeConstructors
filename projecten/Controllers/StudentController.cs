using MySql.Data.MySqlClient;
using projecten.Models;
using projecten.Models.DAL;
using projecten.Models.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        BedrijfRepository bedrijfRep = new BedrijfRepository(context);
        StageOpdrachtRepository stageRep = new StageOpdrachtRepository(context);
        StageBegeleiderRepository begrep = new StageBegeleiderRepository(context);
       // static ProfielModel ProfielModel = new ProfielModel();
        
        
        public ActionResult Index()
        {
            return View();
        }
         [AllowAnonymous]
        public ActionResult Profiel()
        {
            Student student = studentRep.FindBy(User.Identity.Name);
            ProfielModel ProfielModel = new ProfielModel(student);
            try
            {
                var foto = (Byte[])student.foto;
                if(foto != null)
                ProfielModel.foto= Convert.ToBase64String(foto);
                else
                {
                    foto = new byte[20];
                    ProfielModel.foto = Convert.ToBase64String(foto);
                }
                ProfielModel.OudWachtwoord = student.wachtwoord;
                if (ProfielModel.adres == null)
                {
                    ProfielModel.adres = "/";
                }
                if (ProfielModel.gsm == null)
                {
                    ProfielModel.gsm = "/";
                }
                if (ProfielModel.keuzevak == null)
                {
                    ProfielModel.keuzevak = "/";
                }
                if (ProfielModel.naam == null)
                {
                    ProfielModel.naam = "/";
                }
                if (ProfielModel.tweedeEmail == null)
                {
                    ProfielModel.tweedeEmail = "/";
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
                 student.foto = arr;
                 model.foto = Convert.ToBase64String(arr);
             }
            
             var data = (Byte[])student.foto;
             student.setUpdates(model);
           /*  model.OudWachtwoord = student.wachtwoord;
            if (ModelState.IsValid && model.OudWachtwoord == student.wachtwoord)
            {
                student.wachtwoord = model.NieuwWachtwoord;
                
            }
            else
            {

            }*/
             //studentRep.Update(student);
             studentRep.SaveChanges();
             target.Close();
             return View(model);
         }
           [AllowAnonymous]
           public ActionResult Stages()
         {
             
            // if (Request.IsAjaxRequest()) return View();
             var stages = stageRep.FindAll();
             //if (Request.IsAjaxRequest()) return PartialView("StagesList", stages);
             return View(stages);
         }
           [AllowAnonymous]
           [HttpPost]
           public ActionResult Stages(string zoekopdracht)
           {
              
              
                   //  var stages = stageRep.FindAllByName(naam);
                  
                    var stages = stageRep.FindAllBy(zoekopdracht);
                   // List<StageOpdracht> lijst = new List<StageOpdracht>();
                    /*if (gemeente != "")
                    {
                        var bedrijven = bedrijfRep.FindAllByAdres(gemeente);
                        foreach (var item in bedrijven)
                        {
                            lijst.AddRange(stageRep.FindAllByBedrijfId(item.BedrijfId));

                        }*/
                       
                        //stages = lijst;
                    //}
                    
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
               //Bedrijf bedrijf = bedrijfRep.FindBy(stage.Bedrijfid);
               return View(stage);
           }
           [AllowAnonymous]
           [HttpPost]
           public ActionResult Bekijk(int id)
           {
               StageOpdracht stage = stageRep.FindBy(id);
               Student student = studentRep.FindBy(User.Identity.Name);
               
               if (stage.AantalStudenten == 0)
               {
                   
               }
               else
               {
                   StageBegeleider beg = new StageBegeleider();
                   beg.VoegOpdrachtAanBegeleidersToe(begrep.GetBegeleiders(), stage);
                   student.AddStageOpdracht(stage);
                   stage.AantalStudenten -= 1;
               }
               stageRep.Update(stage);
               stageRep.SaveChanges();
               return RedirectToAction("IngenomenStages","Student");
           }
        
    }
}

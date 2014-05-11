using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ninject.Planning.Targets;
using projecten.Models;
using projecten.Models.DAL;
using projecten.Models.Domain;
namespace projecten.Controllers
{
    public class BegeleiderController : Controller
    {
        static BedrijfContext context = new BedrijfContext();
        public StageBegeleiderRepository rep = new StageBegeleiderRepository(context);
        public StudentRepository sturep = new StudentRepository(context);
        public StageOpdrachtRepository StageRep = new StageOpdrachtRepository(context);
        public BedrijfRepository BedrijfRep = new BedrijfRepository(context);
        public ActionResult Index()
        {
            ViewBag.Message = "Index";


            return View();
        }

        public ActionResult Studenten()
        {
            var studenten = sturep.FindAll();
            return View(studenten);
        }

        [HttpPost]
        public ActionResult Studenten(string zoekopdracht)
        {
            var studenten = sturep.FindAllFilter(zoekopdracht);
            return View(studenten);
        }

        public ActionResult StageOpdrachten()
        {
            StageBegeleider beg = rep.FindBy(User.Identity.Name);
            IEnumerable<StageOpdracht> lijst = beg.getIngenomenOpdrachten();
            return View(lijst);
        }

        [HttpPost]
        public ActionResult StageOpdrachten(string zoekopdracht)
        {
            StageBegeleider beg = rep.FindBy(User.Identity.Name);
            IEnumerable<StageOpdracht> lijst = beg.getIngenomenOpdrachten();
            var stages = StageRep.FindAllFilter(lijst, zoekopdracht);
            return View(stages);
        }
        
        
        [AllowAnonymous]
        public ActionResult VoorkeurOpdracht(int id)
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
        public ActionResult VoorkeurOpdracht(int id, StageOpdracht stage)
        {
            if (ModelState.IsValid)
            {
                //stage = StageRep.FindBy(id);
                if (rep.FindBy(User.Identity.Name) != null)
                {
                    StageBegeleider begeleider = rep.FindBy(User.Identity.Name);
                    stage = StageRep.FindBy(id);
                    begeleider.setVoorkeurTrue(stage);
                }
                rep.SaveChanges();
                StageRep.SaveChanges();
                return RedirectToAction("StageOpdrachten");
            }
            /*var viewmodel = new DeleteOpdracht();
            viewmodel.Naam = opdracht.Naam;*/
            return View(stage);
        }
        [AllowAnonymous]
        public ActionResult VoorkeurOpdrachtAnnuleren(int id)
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
        public ActionResult VoorkeurOpdrachtAnnuleren(int id,StageOpdracht stage)
        {
           if (ModelState.IsValid)
            {
                //stage = StageRep.FindBy(id);
                if (rep.FindBy(User.Identity.Name) != null)
                {
                    StageBegeleider begeleider = rep.FindBy(User.Identity.Name);
                    stage = StageRep.FindBy(id);
                    begeleider.setVoorkeurFalse(stage);
                }
                rep.SaveChanges();
                StageRep.SaveChanges();
                return RedirectToAction("StageOpdrachten");
            }
            /*var viewmodel = new DeleteOpdracht();
            viewmodel.Naam = opdracht.Naam;*/
            return View(stage);
        }
        public ActionResult VoorkeurStages()
        {
            StageBegeleider begeleider = rep.FindBy(User.Identity.Name);
            var lijst = rep.FindAll(begeleider);
            return View(lijst);
        }

        [AllowAnonymous]
        public ActionResult ProfielStudent(int id)
        {
            Student student = sturep.FindBy(id);
            return View(student);
        }

        [AllowAnonymous]
        public ActionResult Profiel()
        {
            StageBegeleider begeleider = rep.FindBy(User.Identity.Name);
            try
            {

                var foto = (Byte[])begeleider.Foto;
                if (foto != null)
                {
                    begeleider.FotoString = Convert.ToBase64String(begeleider.Foto);
                }
            }
            catch
            {
                return RedirectToAction("Index", "Begeleider");
            }
           
            return View(begeleider);
        }

        [AllowAnonymous]
        public ActionResult ProfielWijzigen(StageBegeleiderModel model)
        {
            try
            {
                if (rep.FindBy(User.Identity.Name) != null)
                {
                    StageBegeleider begeleider = rep.FindBy(User.Identity.Name);
                    model = new StageBegeleiderModel(begeleider);
                    return View(model);
                }
            }
            catch
            {
                
            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ProfielWijzigen(StageBegeleiderModel model, HttpPostedFileBase image)
        {
            MemoryStream target = new MemoryStream();
            if (ModelState.IsValid)
            {

                    if (rep.FindBy(User.Identity.Name) != null)
                    {
                        StageBegeleider begeleiderupdate = rep.FindBy(User.Identity.Name);
                        byte[] arr = target.ToArray();
                        if (image != null)
                        {
                            image.InputStream.CopyTo(target);

                            arr = target.ToArray();
                            begeleiderupdate.Foto = arr;
                            model.Foto = Convert.ToBase64String(arr);
                        }
                        begeleiderupdate.setUpdates(model);
                    }
                    
                    rep.SaveChanges();
                    target.Close();
                    return RedirectToAction("Profiel");
            }
            if (rep.FindBy(User.Identity.Name) != null)
            {
                StageBegeleider beg = rep.FindBy(User.Identity.Name);
                StageBegeleiderModel begeleider1 = new StageBegeleiderModel(beg);
                target.Close();
                return View(begeleider1);
            }
            target.Close();
            return View(model);
        }

        public ActionResult Bedrijven()
        {
            var bedrijven = BedrijfRep.FindAll();
            return View(bedrijven);
        }

        [HttpPost]
        public ActionResult Bedrijven(string zoekopdracht)
        {
            var bedrijven = BedrijfRep.FindAllFilter(zoekopdracht);
            return View(bedrijven);
        }

        public ActionResult BedrijfsProfiel(int id)
        {
            if (BedrijfRep.FindBy(id) != null)
            {
                Bedrijf bedrijf = BedrijfRep.FindBy(id);
                return View(bedrijf);
            }
            return View(new Bedrijf());
        }

        public ActionResult IngenomenWijzigen(int id)
        {
            StageOpdracht opdracht = StageRep.FindBy(id);
            IngenomenOpdrachtenModel model = new IngenomenOpdrachtenModel(opdracht);
            return View(model);
        }

        [HttpPost]
        public ActionResult IngenomenWijzigen(int id, IngenomenOpdrachtenModel model)
        {
            StageOpdracht opdracht = StageRep.FindBy(id);
            if (ModelState.IsValid)
            {
                opdracht.setUpdates(model);
                StageRep.SaveChanges();
                return RedirectToAction("StageOpdrachten");
            }
            return View(model);
        }

        public ActionResult IngenomenOpdrachten()
        {
            IEnumerable<StageOpdracht> lijst = new List<StageOpdracht>();
            ICollection<StageOpdracht> lijst1 = new Collection<StageOpdracht>();
                lijst = sturep.FindAllStudentOpdrachten(lijst1).AsEnumerable();
            return View(lijst);
        }
    }
}
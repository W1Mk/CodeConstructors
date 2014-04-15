using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using projecten.Models.Domain;
using WebMatrix.WebData;
using System.Web.Security;

namespace projecten.Models.DAL
{
    public class BedrijfInitializer : DropCreateDatabaseIfModelChanges<BedrijfContext>
    {
       
        protected override void Seed(BedrijfContext context)
        {      
            try
            {
               
                Bedrijf ikke = new Bedrijf {Bedrijfsnaam = "ikke", adres = "test", url = "test", Email = "test@test.be", telefoon = "053", Wachtwoord = "yep" };
                StageOpdracht ikkeOpdracht = new StageOpdracht
                {
                    Naam = "ikkeOpdracht",
                    Omschrijving = "tis een opdracht",
                    Semester = "2",
                    Specialisatie = "programmeren",
                    AantalStudenten = "2",
                    StageMentor = "mevr. opdracht"
                };
                //ikke.stages.Add(ikkeOpdracht);
                Student ikke2 = new Student { naam = "ikke", adres = "teststraat", gsm = "0478836695", Email = "peremans.laurens@hogent.be",  wachtwoord= "testen" };      
                context.Bedrijven.Add(ikke);
                //SeedMembership();
                context.SaveChanges();
                //System.Diagnostics.Debug.WriteLine("zou het gelukt zijn?");
     
              /*  StageOpdracht opdracht = new StageOpdracht("test","1");
                StageOpdracht opdracht1 = new StageOpdracht("test2","2");
                List<StageOpdracht> stageOpdrachten =
                   (new StageOpdracht[] { opdracht, opdracht1 }).ToList();
                stageOpdrachten.ForEach(c => context.StageOpdrachten.Add(c));
                Bedrijf denul = new Bedrijf();
                denul.Naam = "Jan De Nul";
                denul.Telefoon = "0123456789";
                denul.Email = "depauwniel@hotmail.com";
                denul.Adres = "baggerlaan 4";
                denul.Url = "www.denul.be";
                denul.Bedrijfsactiviteit = "Bedrijf";
                denul.Bereikbaarheid = "schip";
                denul.Paswoord = "denul";
                denul.AddStageOpdracht(opdracht);
                denul.AddStageOpdracht(opdracht1);
                
                

                context.Bedrijven.Add(denul);
                context.SaveChanges();*/
            }
            catch (DbEntityValidationException e)
            {
                string s = "Fout creatie database ";
                foreach (var eve in e.EntityValidationErrors)
                {
                    s += String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.GetValidationResult());
                    foreach (var ve in eve.ValidationErrors)
                    {
                        s += String.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw new Exception(s);
            }

        }

     
             
    }
}
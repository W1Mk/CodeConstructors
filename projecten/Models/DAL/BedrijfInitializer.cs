using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using projecten.Models.Domain;
using WebMatrix.WebData;
using System.Web.Security;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using projecten.Properties;
namespace projecten.Models.DAL
{
    public class BedrijfInitializer : DropCreateDatabaseAlways<BedrijfContext>
    {

        protected override void Seed(BedrijfContext context)
        {
            try
            {
                var path = AppDomain.CurrentDomain.BaseDirectory + "Images\\anonymous.gif";


                Image img = Image.FromFile(path);

                byte[] arr;
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    arr = ms.ToArray();
                }
                // byte[] photo = GetPhoto("../Images/refresh-button.png");

                Bedrijf ikke = new Bedrijf { Bedrijfsnaam = "ikke", adres = "test", url = "test", Email = "test@test.be", telefoon = "053", Wachtwoord = "yep" };
                StageOpdracht stageopdracht = new StageOpdracht { Naam = "it", Omschrijving = "abc", Semester = 1, AantalStudenten=2, Specialisatie="programmeren", StageMentor="ikke"};
                StageOpdracht stageopdracht2 = new StageOpdracht { Naam = "it2", Omschrijving = "def", Semester = 2, AantalStudenten = 2, Specialisatie = "programmeren", StageMentor = "Lau" };
                StageOpdracht stageopdracht3 = new StageOpdracht { Naam = "it3", Omschrijving = "ghi", Semester = 1, AantalStudenten = 2, Specialisatie = "netwerken", StageMentor = "ikke" };
                Student ikke2 = new Student { naam = "ikke", adres = "teststraat", gsm = "0478836695", Email = "peremans.laurens@hogent.be", wachtwoord = "testen", EersteAanmelding = 1, foto = arr};
                ikke.AddStageOpdracht(stageopdracht);
                ikke.AddStageOpdracht(stageopdracht2);
                ikke.AddStageOpdracht(stageopdracht3);
                context.Bedrijven.Add(ikke);
                context.StageOpdrachten.Add(stageopdracht);
                context.StageOpdrachten.Add(stageopdracht2);
                context.StageOpdrachten.Add(stageopdracht3);
                context.studenten.Add(ikke2);
 
                context.SaveChanges();
                
                

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

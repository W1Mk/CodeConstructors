using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using projecten.Models.Domain;
using System.Drawing;
using System.IO;
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

                Bedrijf ikke = new Bedrijf { Bedrijfsnaam = "ikke", adres = "test", url = "test", Email = "test@test.be", telefoon = "053", Wachtwoord = "yep" };
                StageOpdracht stageopdracht = new StageOpdracht { Naam = "it", Omschrijving = "abc", Semester = "1", AantalStudenten=2, Specialisatie="programmeren", StageMentor="ikke"};
                StageOpdracht stageopdracht2 = new StageOpdracht { Naam = "it2", Omschrijving = "def", Semester = "2", AantalStudenten = 2, Specialisatie = "programmeren", StageMentor = "Lau" };
                StageOpdracht stageopdracht3 = new StageOpdracht { Naam = "it3", Omschrijving = "ghi", Semester = "1", AantalStudenten = 2, Specialisatie = "netwerken", StageMentor = "ikke" };
                ikke.AddStageOpdracht(stageopdracht);
                ikke.AddStageOpdracht(stageopdracht2);
                ikke.AddStageOpdracht(stageopdracht3);
                context.Bedrijven.Add(ikke);
                context.StageOpdrachten.Add(stageopdracht);
                context.StageOpdrachten.Add(stageopdracht2);
                context.StageOpdrachten.Add(stageopdracht3);
 
                context.SaveChanges();
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

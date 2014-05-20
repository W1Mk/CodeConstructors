namespace projecten.Models.Domain
{
    public class StageMentor
    {
        public int StageMentorId { get; set; }        
        public string Naam { get; set; }       
        public string Voornaam { get; set; }       
        public string Email { get; set; }
        public string Gsm { get; set; }     
        public string Functie { get; set; }
        public string Aanspreektitel { get; set; }

        public StageMentor()
        {

        }

        public StageMentor(StageMentorModel model)
        {
            Naam = model.Naam;
            Voornaam = model.Voornaam;
            Email = model.Email;
            Gsm = model.Gsm;
            Functie = model.Functie;
            Aanspreektitel = model.Aanspreektitel;
        }

        public void setUpdates(StageMentorWijzigenModel model)
        {
            Naam = model.Naam;
            Voornaam = model.Voornaam;
            Email = model.Email;
            Gsm = model.Gsm;
            Functie = model.Functie;
            Aanspreektitel = model.Aanspreektitel;
        }
    }
}
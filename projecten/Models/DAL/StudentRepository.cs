using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using projecten.Models.Domain;

namespace projecten.Models.DAL
{
    public class StudentRepository 
    {
         private BedrijfContext context;
        private DbSet<Student> Student;

        public StudentRepository(BedrijfContext context)
        {
            this.context = context;
            Student = context.studenten;
           
        }

        public void Add(Student student)
        {
            Student.Add(student);
        }
        public void Delete(Student student)
        {
            Student.Remove(student);
        }
        public Student  FindBy(int id)
        {
            return Student.Find(id);
        }
        public Student FindBy(String email)
        {
            return Student.FirstOrDefault(s => s.Email == email);
        }
        public IQueryable<Student> FindAllFilter(string zoekopdracht)
        {
            IQueryable<Student> list = null;
            if (Student.Where(b => b.naam == zoekopdracht).Any())
                list = Student.Where(b => b.naam == zoekopdracht);
            else if (Student.Where(b => b.adres == zoekopdracht).Any())
                list = Student.Where(b => b.adres == zoekopdracht);
            else if (Student.Where(b => b.keuzevak == zoekopdracht).Any())
                list = Student.Where(b => b.keuzevak == zoekopdracht);
            else if (Student.Where(b => b.Email == zoekopdracht).Any())
                list = Student.Where(b => b.Email == zoekopdracht);
            else
            {
                list = new List<Student>().AsQueryable();
            }
            if (zoekopdracht == "")
                list = FindAll();
            return list;
        }
        public void Update(Student student)
        {
         
            context.Entry(student).State = EntityState.Modified;
        }
        public IQueryable<Student> FindAll()
        {
            return Student.OrderBy(b => b.naam);
        }

        public IQueryable<StageOpdracht> FindAllStudentOpdrachten(ICollection<StageOpdracht> lijst)
        {
            
            IEnumerable<Student> sublijst = FindAll();//alle studenten
            for (int i = 0; i < sublijst.Count(); i++)
            {
                for (int j = 0; j < sublijst.ElementAt(i).Stageopdrachten.Count(); j++)//opdrachtlijst = sublijst.ElementAt(i).Stageopdrachten
                {

                    if (!lijst.Contains(sublijst.ElementAt(i).Stageopdrachten.ElementAt(j)))
                    {
                        lijst.Add(sublijst.ElementAt(i).Stageopdrachten.ElementAt(j));//voegt opdracht op element j van student i aan de lijst toe
                    }          
                }
            }
            return lijst.AsQueryable();
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
	}
}
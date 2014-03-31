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
        public IQueryable<Student> FindAll()
        {
            return Student.OrderBy(b => b.naam);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
	}
}
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using projecten.Models.Domain;

namespace projecten.Models.DAL
{
    public class AcademieJaarRepository
    {
        private BedrijfContext context;
        private DbSet<AcademieJaar> academieJaren;
        public AcademieJaarRepository(BedrijfContext context)
        {
            this.context = context;
            academieJaren = context.AcademieJaren;
        }

        public IQueryable<AcademieJaar> FindAll()
        {
            return academieJaren.OrderBy(b => b.Academiejaar);
        }

        public SelectList Academiejaren()
        {
            SelectList ac = new SelectList(FindAll());
            return ac;
        }
    }
}
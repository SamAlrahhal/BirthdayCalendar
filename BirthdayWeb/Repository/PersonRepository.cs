using BirthdayWeb.Data;
using BirthdayWeb.Interfaces;
using BirthdayWeb.Models;

namespace BirthdayWeb.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _context;
        public PersonRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Person> GetAllPeople()
        {
            return _context.People.OrderBy(p=>p.Id).ToList();
        }
    }
}

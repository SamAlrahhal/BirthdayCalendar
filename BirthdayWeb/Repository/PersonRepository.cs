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

        public bool CreatePerson(Person person)
        {
            _context.Add(person);
            return Save();
        }

        public ICollection<Person> GetAllPeople()
        {
            return _context.People.ToList();
        }

        public Person GetPerson(int id)
        {
            
            return _context.People.Where(p => p.Id == id).FirstOrDefault();
        }

        public Person GetPersonBirthDate(DateTime birthDate)
        {
            return _context.People.Where(p => p.BirthDate == birthDate).FirstOrDefault();
        }

        public Person GetPersonFristName(string firstName)
        {
            return _context.People.Where(p => p.FirstName == firstName).FirstOrDefault();
        }

        public Person GetPersonLastName(string lastName)
        {
            return _context.People.Where(p => p.LastName == lastName).FirstOrDefault();
        }

        public bool PersonExists(int id)
        {
            return _context.People.Any(p => p.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}

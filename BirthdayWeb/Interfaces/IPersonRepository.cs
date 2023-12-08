using BirthdayWeb.Models;

namespace BirthdayWeb.Interfaces
{
    public interface IPersonRepository
    {
        ICollection<Person> GetAllPeople();
        Person GetPerson(int id);
        Person GetPersonFristName(string firstName);
        Person GetPersonLastName(string lastName);
        Person GetPersonBirthDate(DateTime birthDate);

        bool PersonExists(int id);

        bool CreatePerson(Person person);
        bool Save();
    }
}

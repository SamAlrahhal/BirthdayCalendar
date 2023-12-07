using BirthdayWeb.Models;

namespace BirthdayWeb.Interfaces
{
    public interface IPersonRepository
    {
        ICollection<Person> GetAllPeople();
    }
}

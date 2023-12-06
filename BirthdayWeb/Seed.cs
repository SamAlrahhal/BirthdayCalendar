using BirthdayWeb.Data;
using BirthdayWeb.Models;
using System.Diagnostics.Metrics;

namespace BirthdayWeb
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.People.Any())
            {
                var people = new List<Person>()
                {

                    new Person()
                    {
                        FirstName = "Harry",
                        LastName = "Potter",
                        BirthDate = new DateTime(1980, 7, 31),
                    },
                };
                dataContext.People.AddRange(people);
                dataContext.SaveChanges();
            }
        }
    }
}

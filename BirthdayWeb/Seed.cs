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
                        FirstName = "Hary",
                        LastName = "Potter",
                        BirthDate = new DateTime(1980, 7, 31),
                    },
                    new Person()
                    {
                        FirstName = "Ron",
                        LastName = "Weasley",
                        BirthDate = new DateTime(1980, 3, 1),
                    },
                    new Person()
                    {
                        FirstName = "Hermione",
                        LastName = "Granger",
                        BirthDate = new DateTime(1979, 9, 19),
                    },
                    new Person()
                    {
                        FirstName = "Ginny",
                        LastName = "Weasley",
                        BirthDate = new DateTime(1981, 8, 11),
                    },
                    new Person()
                    {
                        FirstName = "Fred",
                        LastName = "Weasley",
                        BirthDate = new DateTime(1978, 4, 1),
                    },
                    new Person()
                    {
                        FirstName = "George",
                        LastName = "Weasley",
                        BirthDate = new DateTime(1978, 4, 1),
                    }

                };
                dataContext.People.AddRange(people);
                dataContext.SaveChanges();
            }
        }
    }
}

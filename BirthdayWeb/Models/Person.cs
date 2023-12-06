namespace BirthdayWeb.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public int Id { get; set; }

        public Person(string firstName, string lastName, DateTime birthDate, int id)
        {
            this.FirstName = firstName; 
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.Id = id;
        }

        //default constructor
        public Person()
        {
            this.FirstName = "";
            this.LastName = "";
            this.BirthDate = DateTime.MinValue;
            this.Id = 0;
        }

    }
}

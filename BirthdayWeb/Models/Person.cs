namespace BirthdayWeb.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }

        public Person(string firstName, string lastName, DateOnly birthDate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
        }

        //default constructor
        public Person()
        {
            this.FirstName = "";
            this.LastName = "";
            this.BirthDate = DateOnly.MinValue; // or any default date you want
        }

    }
}

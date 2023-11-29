using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
 

namespace BirthdayBackend
{
    public class ShowAllBE
    {
        public ObservableCollection<Person>? People { get; set; }





        public ObservableCollection<Person> MakePpl()
        {
            People = new ObservableCollection<Person>
            {
                new Person("John", "Doe", DateOnly.Parse("11/07/1990")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("JeffreyEpstienNogger", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("samaloen", "alrahhoel", DateOnly.Parse("01/09/1950")),
                new Person("jalereen", "Doeleeen", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),
                new Person("Jane", "Doe", DateOnly.Parse("01/09/1950")),

            };
            return People;
        }
    }
}
using System.Collections.ObjectModel;
using BirthdayBackend;

namespace BirthdayCalendar
{
    public partial class ShowAll : ContentPage
    {
        private ShowAllBE showBackEnd = new ShowAllBE();
        public ObservableCollection<Person> People { get; set; }

        public ShowAll()
        {
            InitializeComponent();


            // Set the BindingContext to this instance of ShowAll
            People = showBackEnd.MakePpl();
            
            this.BindingContext = this;
        }
    }
}

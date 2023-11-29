using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using BirthdayBackend;

namespace BirthdayCalendar
{
    public partial class ShowAll : ContentPage, INotifyPropertyChanged
    {
        private ShowAllBE showBackEnd = new ();

        public ObservableCollection<Person> People { get; set; }

        public ShowAll()
        {
            InitializeComponent();




            // Set the BindingContext to this instance of ShowAll
            People = showBackEnd.MakePpl();
            
            this.BindingContext = this;
        }

        void OnEditClicked(object sender, EventArgs e)
        {
            Debug.Print("person edit");
             Navigation.PushAsync(new EditPerson());



        }
    }
}

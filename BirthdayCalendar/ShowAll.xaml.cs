//using BirthdayBackend;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using BirthdayCalendar.Service;
using BirthdayCalendar.Models;
using Newtonsoft.Json;

namespace BirthdayCalendar
{
    public partial class ShowAll : ContentPage, INotifyPropertyChanged
    {
        private ObservableCollection<Person> _people;
        public ObservableCollection<Person> People
        {
            get { return _people; }
            set
            {
                _people = value;
                OnPropertyChanged(nameof(People));
            }
        }
        public ShowAll()
        {
            InitializeComponent();

            // Set the BindingContext to this instance of ShowAll

            ShowAllPpl();
            this.BindingContext = this;
        }

        void OnEditClicked(object sender, EventArgs e)
        {
            Debug.Print("person edit");
            Navigation.PushAsync(new EditPerson());

        }

        public async void ShowAllPpl()
        {
            var httpClient = new HttpClient();
            var responce = await httpClient.GetAsync("https://localhost:44323/api/Person");

            if (responce.IsSuccessStatusCode)
            {
                var content = await responce.Content.ReadAsStringAsync();
                var people = JsonConvert.DeserializeObject<IEnumerable<Person>>(content);
                if (People == null)
                {
                    People = new ObservableCollection<Person>();
                }
                People.Clear();
                foreach (var person in people)
                {
                    People.Add(person);
                }
                Debug.WriteLine($"People: {people}");
            }
            else
            {
                Debug.WriteLine($"Error: {responce.StatusCode}");
            }
        }


        


        void OnAddPersonClicked(object sender, EventArgs e)
        {

             Navigation.PushAsync(new addPerson());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

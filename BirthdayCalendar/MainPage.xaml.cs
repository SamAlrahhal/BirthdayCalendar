//using BirthdayBackend;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using BirthdayCalendar.Models;
using Newtonsoft.Json;
namespace BirthdayCalendar
{


    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {

        public static int PersonIdToPass { get; set; }

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
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            //ShowAllRecent();
            this.BindingContext = this;

        }
        private async void ShowAllRecent()
        {
            var httpClient = new HttpClient();
            var url = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5279/api/Person" : "http://localhost:5279/api/Person";
            var response = await httpClient.GetAsync(url);
            //shows  everyone whos birhtday comes recentlly 
            //everyone whos birthday comes up this today, week and this month
            Debug.Write("there is a connnectios");

            ThisDay();
            ThisWeek();
            ThisMonth();
        }

        private async void ThisMonth()
        {
            var httpClient = new HttpClient();
            var url = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5279/api/Person"
                : "http://localhost:5279/api/Person";

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                Debug.Write("there is a connnectios");
                var content = await response.Content.ReadAsStringAsync();
                var people = JsonConvert.DeserializeObject<IEnumerable<Person>>(content);

                if (People == null)
                {
                    People = new ObservableCollection<Person>();
                }

                People.Clear();

                // Get current month
                var currentMonth = DateTime.Now.Month;

                // Filter for birthdays in the current month
                var birthdaysThisMonth = people
                    .Where(person => person.BirthDate.Month == currentMonth);


                // Populate the collection with filtered results
                foreach (var person in birthdaysThisMonth)
                {
                    People.Add(person);
                }

                // Debug output
                foreach (var person in People)
                {
                    Debug.WriteLine($"This Month's Birthday: {person.FirstName} {person.LastName}, Birthday: {person.BirthDate}");
                }
            }
            else
            {
                Debug.WriteLine($"Error: {response.StatusCode}");
            }
        }


        private async void ThisWeek()
        {

        }

        private async void ThisDay()
        {

        }


        void OnAddPersonClicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new addPerson());
        }

        void OnShowAllClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShowAll());
        }
    }
}

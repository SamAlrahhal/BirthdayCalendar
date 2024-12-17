using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using BirthdayCalendar.Models;
using Newtonsoft.Json;

namespace BirthdayCalendar
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public ObservableCollection<Person> PeopleToday { get; set; } = new ObservableCollection<Person>();
        public ObservableCollection<Person> PeopleThisWeek { get; set; } = new ObservableCollection<Person>();
        public ObservableCollection<Person> PeopleThisMonth { get; set; } = new ObservableCollection<Person>();

        public MainPage()
        {
            InitializeComponent();
            ShowAllRecent();
            this.BindingContext = this;
        }

        private async void ShowAllRecent()
        {
            await ThisDay();
            await ThisWeek();
            await ThisMonth();
        }

        private async Task ThisDay()
        {
            await LoadBirthdays((person) =>
            {
                var today = DateTime.Now;
                return person.BirthDate.Day == today.Day && person.BirthDate.Month == today.Month;
            }, PeopleToday, "Today's Birthday");
        }

        private async Task ThisWeek()
        {
            await LoadBirthdays((person) =>
            {
                var today = DateTime.Now;
                var startOfWeek = today.AddDays(-(int)today.DayOfWeek);
                var endOfWeek = startOfWeek.AddDays(7);
                var personBirthday = new DateTime(today.Year, person.BirthDate.Month, person.BirthDate.Day);
                return personBirthday >= startOfWeek && personBirthday < endOfWeek;
            }, PeopleThisWeek, "This Week's Birthday");
        }

        private async Task ThisMonth()
        {
            await LoadBirthdays((person) =>
            {
                var currentMonth = DateTime.Now.Month;
                return person.BirthDate.Month == currentMonth;
            }, PeopleThisMonth, "This Month's Birthday");
        }

        private async Task LoadBirthdays(Func<Person, bool> filter, ObservableCollection<Person> targetCollection, string logMessage)
        {
            var httpClient = new HttpClient();
            var url = DeviceInfo.Platform == DevicePlatform.Android
                ? "http://10.0.2.2:5279/api/Person"
                : "http://localhost:5279/api/Person";

            try
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var people = JsonConvert.DeserializeObject<IEnumerable<Person>>(content);

                    targetCollection.Clear();

                    foreach (var person in people.Where(filter))
                    {
                        targetCollection.Add(person);
                        Debug.WriteLine($"{logMessage}: {person.FirstName} {person.LastName}, Birthday: {person.BirthDate}");
                    }
                }
                else
                {
                    Debug.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.Message}");
            }
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

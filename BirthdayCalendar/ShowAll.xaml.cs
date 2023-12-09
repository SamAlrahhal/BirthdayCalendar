//using BirthdayBackend;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using BirthdayCalendar.Models;
using Newtonsoft.Json;

namespace BirthdayCalendar
{
    public partial class ShowAll : ContentPage, INotifyPropertyChanged
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
        public ShowAll()
        {
            InitializeComponent();

            // Set the BindingContext to this instance of ShowAll

            ShowAllPpl();
            this.BindingContext = this;
        }

        void OnEditClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int personId = (int)button.CommandParameter;
            PersonIdToPass = personId;
            Navigation.PushAsync(new EditPerson());

        }

        public async void ShowAllPpl()
        {

            var httpClient = new HttpClient();
            var url = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5129/api/Person" : "http://localhost:5129/api/Person";
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
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
                foreach (var person in People)
                {
                    Debug.WriteLine($"People: {person.FirstName}", $"Ids: { person.Id}");
                }
            }
            else
            {
                Debug.WriteLine($"Error: {response.StatusCode}");
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

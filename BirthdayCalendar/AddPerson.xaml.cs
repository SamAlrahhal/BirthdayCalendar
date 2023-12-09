using Newtonsoft.Json;
using System.Diagnostics;
using BirthdayCalendar.Models;
using System.Text;


namespace BirthdayCalendar;

public partial class addPerson : ContentPage
{
    public addPerson()
    {
        InitializeComponent();
    }

    async void OnAddPersonClicked(object sender, EventArgs e)
    {
        var httpClient = new HttpClient();
        var url = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5129/api/Person" : "http://localhost:5129/api/Person";



        // Get the person data from the UI elements
        string firstName = FirstNameEntry.Text;
        string lastName = LastNameEntry.Text;
        DateTime birthDate = DateOfBirthDatePicker.Date;

        // Create a new Person object
        Person person = new Person()
        {
            FirstName = firstName,
            LastName = lastName,
            BirthDate = birthDate
        };

        // Serialize the person object to JSON
        string json = JsonConvert.SerializeObject(person);

        // Send an HTTP POST request to the API endpoint
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync(url, content);
        // Check the response status code
        if (response.IsSuccessStatusCode)
        {

            // Clear the UI entries
            FirstNameEntry.Text = "";
            LastNameEntry.Text = "";
            DateOfBirthDatePicker.Date = DateTime.MaxValue;
        }
        else
        {
            // Display an error message
            _ = DisplayAlert("Error Adding Person", "An error occurred while adding the person.", "OK");
        }
        await Navigation.PushAsync(new ShowAll());

    }


}
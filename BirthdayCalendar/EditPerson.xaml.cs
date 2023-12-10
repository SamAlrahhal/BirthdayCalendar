using Newtonsoft.Json;
using System.Diagnostics;
using BirthdayCalendar.Models;
using System.Text;

namespace BirthdayCalendar;

public partial class EditPerson : ContentPage
{
    int idToUse = ShowAll.PersonIdToPass;

    public EditPerson()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        using (var httpClient = new HttpClient())
        {
            var url = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5279/api/Person" : "http://localhost:5279/api/Person";
            var response = await httpClient.GetAsync(url + "/" + idToUse);
            if (response.IsSuccessStatusCode)
            {
                var personJson = await response.Content.ReadAsStringAsync();
                var person = JsonConvert.DeserializeObject<Person>(personJson);

                FirstNameEntry.Text = person.FirstName;
                LastNameEntry.Text = person.LastName;
                DateOfBirthDatePicker.Date = person.BirthDate;
            }
        }
    }


    async void OnSavePesonClicked(object sender, EventArgs e)
    {
        var httpClient = new HttpClient();
        var url = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5279/api/Person" : "http://localhost:5279/api/Person";

        // Create a new Person object with updated data
        Person person = new Person()
        {
            Id = idToUse,
            FirstName = FirstNameEntry.Text,
            LastName = LastNameEntry.Text,
            BirthDate = DateOfBirthDatePicker.Date
        };

        // Serialize the person object to JSON
        string json = JsonConvert.SerializeObject(person);

        // Send an HTTP PUT request to the API endpoint
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PutAsync(url + "/" + idToUse, content);

        // Check the response status code
        if (response.IsSuccessStatusCode)
        {
            Debug.Print("Person updated successfully");
        }
        else
        {
            Debug.Print("Failed to update person");
        }

        // Navigate to the ShowAll page
        await Navigation.PushAsync(new ShowAll());
    }
    async void OnDeletePersonClicked(object sender, EventArgs e)
    {
        var httpClient = new HttpClient();
        var url = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5279/api/Person" : "http://localhost:5279/api/Person";
        var response = await httpClient.DeleteAsync(url + "/" + idToUse);
        if (response.IsSuccessStatusCode)
        {
            Debug.Print("Deleted");
        }
        else
        {
            Debug.Print("Not Deleted");
        }
        await Navigation.PushAsync(new ShowAll());

    }


}
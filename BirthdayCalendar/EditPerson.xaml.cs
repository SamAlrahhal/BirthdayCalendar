using System.Diagnostics;
namespace BirthdayCalendar;

public partial class EditPerson : ContentPage
{
    int idToUse = ShowAll.PersonIdToPass;

    public EditPerson()
    {
        InitializeComponent();
    }

    void OnSavePesonClicked(object sender, EventArgs e)
    {
        Debug.Print("save");
        Navigation.PushAsync(new ShowAll());

    }
    async void OnDeletePersonClicked(object sender, EventArgs e)
    {
        var httpClient = new HttpClient();
        var url = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5129/api/Person" : "http://localhost:5129/api/Person";
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
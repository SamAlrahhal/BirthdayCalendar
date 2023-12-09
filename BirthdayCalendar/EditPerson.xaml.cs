using System.Diagnostics;
namespace BirthdayCalendar;

public partial class EditPerson : ContentPage
{
    public EditPerson()
    {
        InitializeComponent();
    }

    void OnSavePesonClicked(object sender, EventArgs e)
    {
        Debug.Print("save");
        Navigation.PushAsync(new ShowAll());

    }    void OnDeletePersonClicked(object sender, EventArgs e)
    {
        Debug.Print("save");
        Navigation.PushAsync(new ShowAll());

    }


}
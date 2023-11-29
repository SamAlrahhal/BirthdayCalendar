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
    }

    void OnDeletePersonClicked(object sender, EventArgs e)
    {
        Debug.Print("deleted");

    }
}
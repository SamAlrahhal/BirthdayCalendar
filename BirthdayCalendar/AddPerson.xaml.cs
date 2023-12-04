using System.Diagnostics;

namespace BirthdayCalendar;

public partial class addPerson : ContentPage
{
    public addPerson()
    {
        InitializeComponent();
    }

    void OnAddPersonClicked(object sender, EventArgs e)
    {
        Debug.Print("somethign");
    }

}
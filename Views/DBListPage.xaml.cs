using Matkgo.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace Matkgo.Views;

public partial class DBListPage : ContentPage
{
	public DBListPage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        guidesList.ItemsSource = GuidesPage.Database.GetItems();
        base.OnAppearing();
    }
    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        HikingGuide selectedGuide = e.SelectedItem as HikingGuide;
        DBGuidePage guidePage = new DBGuidePage();
        guidePage.BindingContext= selectedGuide;
        await Navigation.PushAsync(guidePage);
    }

    private async void CreateGuide(object sender, EventArgs e)
    {
        HikingGuide guide = new HikingGuide();
        DBGuidePage guidePage = new DBGuidePage();
        guidePage.BindingContext= guide;
        await Navigation.PushAsync(guidePage);
    }

}
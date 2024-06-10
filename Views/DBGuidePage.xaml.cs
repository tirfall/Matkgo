using Matkgo.Models;
using Plugin.Media.Abstractions;
using Plugin.Media;
using Microsoft.Maui.Controls;

namespace Matkgo.Views;

public partial class DBGuidePage : ContentPage
{
	public DBGuidePage()
	{
		InitializeComponent();
        Loaded += DBGuidePage_Loaded;
	}

    private void DBGuidePage_Loaded(object sender, EventArgs e)
    {
        HikingGuide guide = (HikingGuide)BindingContext;
    }

    private void SaveGuide(object sender, EventArgs e)
    {
        HikingGuide guide = (HikingGuide)BindingContext;
        if (new string[] {guide.Title,guide.Description,guide.Equipment,guide.SafetyTips}.All(x => !string.IsNullOrEmpty(x)))
            GuidesPage.Database.SaveItem(guide);
        Navigation.PopAsync();
    }

    private void DeleteGuide(object sender, EventArgs e)
    {
        HikingGuide guide = (HikingGuide)BindingContext;
        GuidesPage.Database.DeleteItem(guide.Id);
        Navigation.PopAsync();
    }

    private void Cancel(object sender, EventArgs e) { Navigation.PopAsync(); }
        

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await CrossMedia.Current.Initialize();
        MediaFile new_image = await CrossMedia.Current.PickPhotoAsync();
        HikingGuide guide = (HikingGuide)BindingContext;
        Stream stream = await ((StreamImageSource)ImageSource.FromStream(new_image.GetStream)).Stream(CancellationToken.None);
        GuidesPage.Database.SaveItem(guide);
    }
}
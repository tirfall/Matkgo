using Matkgo.Views;
using Matkgo.ViewModels;

namespace Matkgo.Views;

public partial class GuidePage : ContentPage
{
	public GuideViewModel ViewModel { get; private set; }
	public GuidePage(GuideViewModel vm)
	{
		InitializeComponent();
		ViewModel = vm;
		BindingContext = ViewModel;
	}
}
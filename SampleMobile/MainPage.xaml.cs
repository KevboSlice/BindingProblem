using SampleMobile.ViewModels;

namespace SampleMobile;

public partial class MainPage : ContentPage
{

	public MainPage(MainPageViewModel model)
	{
		InitializeComponent();
		this.BindingContext = model;
	}
}


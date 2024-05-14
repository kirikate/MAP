using MAP.Helpers;
using MAP.Platforms.Android.PlatfomPages.ViewModels;

namespace MAP.Platforms.Android.PlatfomPages.Views;

public partial class OrientationView : ContentPage
{
	public OrientationView()
	{
		InitializeComponent();
		BindingContext = ServiceHelper.ServiceProvider.GetRequiredService<OrientationViewModel>();
	}

	protected override bool OnBackButtonPressed()
	{
		ArgsHelper.Clear();
		if (BindingContext is OrientationViewModel vm)
		{
			vm.ClearThings();
		}
		return base.OnBackButtonPressed();
	}
}
using MAP.Helpers;
using MAP.Services;
using MAP.ViewModels;

namespace MAP.Views;

public partial class MainPage : ContentPage
{
	MainPageViewModel vm;
	public MainPage()
	{
		InitializeComponent();
		IThemeService ts = ServiceHelper.ServiceProvider.GetService<IThemeService>();
		ts.SetCurrentTheme(ts.GetCurrentTheme());
		vm = ServiceHelper.ServiceProvider.GetRequiredService<MainPageViewModel>();
	}
	protected override void OnSizeAllocated(double width, double height)
	{
		base.OnSizeAllocated(width, height);
		if (width < height)
		{
			wrapper.Children.Clear();
			wrapper.Children.Add(new MainPageVerticalView(vm));
		}
		else
		{
			wrapper.Children.Clear();
			wrapper.Children.Add(new MainPageHorizontalView(vm));
		}
	}
}
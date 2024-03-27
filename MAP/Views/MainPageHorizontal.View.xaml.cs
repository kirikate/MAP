using MAP.ViewModels;

namespace MAP.Views;

public partial class MainPageHorizontalView : ContentView
{
	public MainPageHorizontalView(MainPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
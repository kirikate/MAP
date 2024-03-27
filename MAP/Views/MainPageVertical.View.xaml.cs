using MAP.ViewModels;

using MAP.Helpers;
using MAP.ViewModels;

namespace MAP.Views;

public partial class MainPageVerticalView : ContentView
{
	int count = 0;

	public MainPageVerticalView(MainPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

}



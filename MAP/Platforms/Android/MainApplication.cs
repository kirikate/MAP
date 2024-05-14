using Android.App;
using Android.Runtime;
using MAP.Platforms.Android.PlatfomPages.ViewModels;
using MAP.Platforms.Android.PlatfomPages.Views;

namespace MAP
{
	[Application]
	public class MainApplication : MauiApplication
	{
		public MainApplication(IntPtr handle, JniHandleOwnership ownership)
			: base(handle, ownership)
		{
		}

		protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp((IServiceProvider, obj) => new OrientationView(), typeof(OrientationViewModel));
	}
}

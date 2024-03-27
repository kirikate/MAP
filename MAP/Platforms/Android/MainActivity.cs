using Android.App;
using Android.Content.PM;
using Android.OS;

namespace MAP
{
	[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density, ScreenOrientation=ScreenOrientation.User)]
	public class MainActivity : MauiAppCompatActivity
	{
	}
}

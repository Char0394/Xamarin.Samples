using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace IntroductionUISample.Droid
{
	[Activity(Label = "IntroductionUISample.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			var pixelWidth = (int)Resources.DisplayMetrics.WidthPixels;
			var pixelHeight = (int)Resources.DisplayMetrics.HeightPixels;
			var screenPixelDensity = (double)Resources.DisplayMetrics.Density;


			App.ScreenHeight = (double)((pixelHeight - 0.5f) / screenPixelDensity);
			App.ScreenWidth = (double)((pixelWidth - 0.5f) / screenPixelDensity);

			StatusBarHelper.DecorView = this.Window.DecorView;

			LoadApplication(new App());
		}
	}
}

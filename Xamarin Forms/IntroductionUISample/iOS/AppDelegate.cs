using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace IntroductionUISample.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();


			App.ScreenWidth = (double)UIScreen.MainScreen.Bounds.Width;
			App.ScreenHeight = (double)UIScreen.MainScreen.Bounds.Height;

			DeviceHelper.iOSDevice = UIDevice.CurrentDevice;


			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}

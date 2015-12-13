using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using PushNotificationSample.Models.Responses;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using PushNotificationSample.Services;
using PushNotification.Plugin.Abstractions;

namespace PushNotificationSample
{
	[Activity (Label = "PushNotificationSample", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);


			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.registrationButton);
			var pushNotification=TinyIoC.TinyIoCContainer.Current.Resolve<IPushNotification> ();

			if(!string.IsNullOrEmpty(pushNotification.Token))
			{
				button.Text = Resources.GetString(Resource.String.Unregister);
			}
			else
			{
				button.Text = Resources.GetString(Resource.String.register);
			}

			button.Click += delegate {
				
				if(string.IsNullOrEmpty(pushNotification.Token))
				{
					pushNotification.Register();
					button.Text = Resources.GetString(Resource.String.Unregister);
				}
				else
				{
					pushNotification.Unregister();
					button.Text = Resources.GetString(Resource.String.register);
				}

			};
		}



	}
}



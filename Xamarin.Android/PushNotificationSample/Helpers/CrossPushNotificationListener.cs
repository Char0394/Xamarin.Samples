using System;
using PushNotification.Plugin;
using PushNotificationSample.Services;

namespace PushNotificationSample.Helpers
{
	public class CrossPushNotificationListener : IPushNotificationListener
	{

		#region IPushNotificationListener implementation

		public async void OnMessage (Newtonsoft.Json.Linq.JObject values, PushNotification.Plugin.Abstractions.DeviceType deviceType)
		{
			
			Console.WriteLine ("Message Received");
		}
			

		public async void OnRegistered (string Token, PushNotification.Plugin.Abstractions.DeviceType deviceType)
		{
			await TinyIoC.TinyIoCContainer.Current.Resolve<IApiService> ().RegisterDeviceAsync ("android", Token);
			Console.WriteLine ("Registered");

		}

		public void OnUnregistered (PushNotification.Plugin.Abstractions.DeviceType deviceType)
		{
			Console.WriteLine ("Unregistered");
		}

		public void OnError (string message, PushNotification.Plugin.Abstractions.DeviceType deviceType)
		{
			Console.WriteLine (message);
		}

		public bool ShouldShowNotification ()
		{
			return true;
		}

		#endregion
	}
}


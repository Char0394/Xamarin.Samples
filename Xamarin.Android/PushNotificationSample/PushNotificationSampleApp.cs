using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Runtime;
using PushNotification.Plugin;
using TinyIoC;
using PushNotificationSample.Services;
using PushNotification.Plugin.Abstractions;
using PushNotificationSample.Helpers;

namespace PushNotificationSample
{
    //This is a starting point application class so that push notifications can be handle even when push is closed.

    [Application]
    public class PushNotificationSampleApp : Application
    {
		public static Context AppContext;

		public PushNotificationSampleApp(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{

		}

		public override void OnCreate()
		{
			base.OnCreate();

			AppContext = this.ApplicationContext;

			CrossPushNotification.Initialize<CrossPushNotificationListener>(Constants.GcmSenderId);
		

			var container = TinyIoCContainer.Current;

			container.Register<IApiService, ApiService> (new ApiService(Constants.ApiUrl));
			container.Register<IPushNotification> (CrossPushNotification.Current);
		          
             

			StartPushService();
		}

		public static void StartPushService()
		{
			AppContext.StartService(new Intent(AppContext, typeof(PushNotificationService)));

			if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
			{
		
				PendingIntent pintent = PendingIntent.GetService(AppContext, 0, new Intent(AppContext, typeof(PushNotificationService)), 0);
				AlarmManager alarm = (AlarmManager)AppContext.GetSystemService(Context.AlarmService);
				alarm.Cancel(pintent);
			}
		}

		public static void StopPushService()
		{
			AppContext.StopService(new Intent(AppContext, typeof(PushNotificationService)));
                        if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
			{
			    PendingIntent pintent = PendingIntent.GetService(AppContext, 0, new Intent(AppContext, typeof(PushNotificationService)), 0);
			    AlarmManager alarm = (AlarmManager)AppContext.GetSystemService(Context.AlarmService);
			    alarm.Cancel(pintent);
			}
		}

    }
}

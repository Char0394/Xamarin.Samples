using System;

using Xamarin.Forms;

namespace FormsTabsSample
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application

			MainPage = new PrettyTabbedPage
			{
				ShowTitles=false,
				Children = 
				{  
					new TabOnePage(){ Title="1", Icon="homedisabled", SelectedIcon="homeenabled" },
					new TabTwoPage(){ Title="2", Icon="notificationenable", SelectedIcon="notificationdisabled" },
					new TabThreePage(){ Title="3", Icon="settingdisabled", SelectedIcon="settingenabled" },
					new TabFourPage(){ Title="4", Icon="flagdisabled", SelectedIcon="flagenabled" },
					new TabFivePage(){ Title="5", Icon="messagedisabled", SelectedIcon="messageenabled"  }

				}
			};

		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes

		}
	}
}


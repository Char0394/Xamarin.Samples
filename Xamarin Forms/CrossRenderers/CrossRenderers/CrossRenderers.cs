using System;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace CrossRenderers
{
	public class App : Application
	{
		DrawView drawView;
		public App ()
		{
			drawView = new DrawView {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.White,
				DrawColor = Color.Red
			};
			// The root page of your application
			MainPage = new ContentPage {
				Content = drawView
			};
		}

		protected async override void OnStart ()
		{
			await Task.Delay (2000);
			drawView.DrawColor=Color.Blue;
			await Task.Delay (2000);
			drawView.DrawColor=Color.Olive;
			await Task.Delay (2000);
			drawView.DrawColor=Color.Green;
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


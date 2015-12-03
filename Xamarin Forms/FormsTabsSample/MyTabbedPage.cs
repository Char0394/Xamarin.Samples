using System;
using Xamarin.Forms;

namespace FormsTabsSample
{
	public class MyTabbedPage : TabbedPage
	{

		public static readonly BindableProperty ShowTitlesProperty =
			BindableProperty.Create ("ShowTitles", typeof(bool), typeof(MyTabbedPage), true);

		public bool ShowTitles
		{
			get { return (bool)GetValue (ShowTitlesProperty); }
			set { SetValue (ShowTitlesProperty, value); }
		}
	}
}


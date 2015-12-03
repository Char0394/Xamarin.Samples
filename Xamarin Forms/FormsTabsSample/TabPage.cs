using System;
using Xamarin.Forms;

namespace FormsTabsSample
{
	public class TabPage : ContentPage
	{
		public static readonly BindableProperty SelectedIconProperty =
			BindableProperty.Create ("SelectedIcon", typeof(FileImageSource), typeof(TabPage), default(FileImageSource));

		public FileImageSource SelectedIcon {
			get { return (FileImageSource)GetValue (SelectedIconProperty); }
			set { SetValue (SelectedIconProperty, value); }
		}
	}
}


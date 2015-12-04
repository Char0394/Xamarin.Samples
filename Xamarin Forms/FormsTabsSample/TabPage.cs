using System;
using Xamarin.Forms;

namespace FormsTabsSample
{
	public class TabPage : ContentPage
	{
		public TabPage(string name)
		{
			Content = new StackLayout 
			{ 
				Children = 
				{
					new Label { Text = name,  FontSize = Device.GetNamedSize (NamedSize.Large, typeof(Label)), FontAttributes = FontAttributes.Bold, VerticalOptions=LayoutOptions.CenterAndExpand , HorizontalOptions = LayoutOptions.CenterAndExpand},
				}
			};
		}
		public static readonly BindableProperty SelectedIconProperty =
			BindableProperty.Create ("SelectedIcon", typeof(FileImageSource), typeof(TabPage), default(FileImageSource));

		public FileImageSource SelectedIcon {
			get { return (FileImageSource)GetValue (SelectedIconProperty); }
			set { SetValue (SelectedIconProperty, value); }
		}
	}
}


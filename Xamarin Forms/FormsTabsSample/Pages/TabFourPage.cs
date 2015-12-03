using System;

using Xamarin.Forms;
using System.Diagnostics;

namespace FormsTabsSample
{
	public class TabFourPage : TabPage
	{
		public TabFourPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Four" }
				}
			};
		}
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			Debug.WriteLine ("4");
		}
	}
}



using System;

using Xamarin.Forms;
using System.Diagnostics;

namespace FormsTabsSample
{
	public class TabThreePage : TabPage
	{
		public TabThreePage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Three" }
				}
			};
		}
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			Debug.WriteLine ("3");
		}
	}
}



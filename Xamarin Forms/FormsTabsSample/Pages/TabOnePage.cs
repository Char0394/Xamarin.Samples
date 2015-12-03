using System;

using Xamarin.Forms;
using System.Diagnostics;

namespace FormsTabsSample
{
	public class TabOnePage : TabPage
	{
		public TabOnePage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "One" }
				}
			};
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			Debug.WriteLine ("1");
		}
	}
}



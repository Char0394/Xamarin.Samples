using System;

using Xamarin.Forms;
using System.Diagnostics;

namespace FormsTabsSample
{
	public class TabTwoPage : TabPage
	{
		public TabTwoPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Two" }
				}
			};
		}
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			Debug.WriteLine ("2");
		}
	}
}



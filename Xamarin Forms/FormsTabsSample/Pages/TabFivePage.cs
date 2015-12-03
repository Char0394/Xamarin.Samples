using System;

using Xamarin.Forms;
using System.Diagnostics;

namespace FormsTabsSample
{
	public class TabFivePage : TabPage
	{
		public TabFivePage ()
		{
			Content = new StackLayout { 
				
				Children = {
					new Label { Text = "Five" },
				}
			};
		}
	}
}



using System;
using Xamarin.Forms;

namespace CrossRenderers
{
	public class DrawView : View
	{
		public static readonly BindableProperty DrawColorProperty = BindableProperty.Create<DrawView,Color>(p => p.DrawColor, Color.Black);

		public Color DrawColor {
			get { return (Color)GetValue (DrawColorProperty); }
			set { SetValue (DrawColorProperty, value); }
		}

		/*public event EventHandler Clicked = delegate {}; 

		public void OnClicked(object sender, EventArgs e)
		{
			var handler = Clicked;
			if (handler != null)
			{
				handler(this, e);
			}
		}*/
	}
}


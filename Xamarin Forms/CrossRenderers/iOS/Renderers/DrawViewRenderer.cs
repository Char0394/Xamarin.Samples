using System;
using Xamarin.Forms;
using CrossRenderers;
using CrossRenderers.iOS;
using CoreGraphics;
using UIKit;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(DrawView),typeof(DrawViewRenderer))]
namespace CrossRenderers.iOS
{
	public class DrawViewRenderer : ViewRenderer<DrawView,NativeDrawView>
	{

		UIView View { get; set; }
		protected override void OnElementChanged (ElementChangedEventArgs<DrawView> e)
		{
			base.OnElementChanged (e);

			if (Control == null)
			{
				SetNativeControl (new NativeDrawView());
		     }

			if (e.NewElement != null) 
			{
				Control.PaintColor = e.NewElement.DrawColor.ToUIColor();
			}
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == DrawView.DrawColorProperty.PropertyName)
				Control.PaintColor = Element.DrawColor.ToUIColor();
		}

	}
}


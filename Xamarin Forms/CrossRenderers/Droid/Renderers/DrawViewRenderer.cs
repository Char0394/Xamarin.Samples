using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using CrossRenderers;
using CrossRenderers.Droid;

[assembly: ExportRenderer(typeof(DrawView),typeof(DrawViewRenderer))]
namespace CrossRenderers.Droid
{
	public class DrawViewRenderer : ViewRenderer<DrawView,NativeDrawView>
	{
		protected override void OnElementChanged (ElementChangedEventArgs<DrawView> e)
		{
			base.OnElementChanged (e);

			if (Control == null) 
				SetNativeControl (new NativeDrawView (Android.App.Application.Context));

			if (e.NewElement != null)
				Control.PaintColor = e.NewElement.DrawColor.ToAndroid();
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == DrawView.DrawColorProperty.PropertyName)
				Control.PaintColor = Element.DrawColor.ToAndroid ();
		}
	}
}


using System;
using CoreGraphics;
using UIKit;
using System.Drawing;

namespace CrossRenderers.iOS
{
	public class NativeDrawView : UIView
	{
		nfloat brush = 10.0f;
		nfloat opacity = 1.0f;
		CGPoint lastPoint;
		bool swiped;
		UIImageView tempDrawImage;
		UIImageView mainImage;

		public UIColor PaintColor { get ; set ; }

		public NativeDrawView ()
		{
			PaintColor = UIColor.Black;
			AutoresizingMask = UIViewAutoresizing.All;
			mainImage = new UIImageView () {
		
				AutoresizingMask = UIViewAutoresizing.All,
				Image=CreateImageFromColor()
			};

			tempDrawImage = new UIImageView () {

				AutoresizingMask = UIViewAutoresizing.All,
				Image=CreateImageFromColor()
			};

			Add (tempDrawImage);
			Add (mainImage);
		}
		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			mainImage.Frame = Frame;
			tempDrawImage.Frame = Frame;
		}
		public override void TouchesBegan (Foundation.NSSet touches, UIKit.UIEvent evt)
		{

			swiped = false;
			UITouch touch = touches.AnyObject as UITouch ;
			lastPoint = touch.LocationInView (this);
		}

		public override void TouchesMoved (Foundation.NSSet touches, UIEvent evt)
		{

			swiped = true;
			UITouch touch = touches.AnyObject as UITouch;

			CGPoint currentPoint= touch.LocationInView (this);

			UIGraphics.BeginImageContext(Frame.Size);
			tempDrawImage.Image.Draw(new CGRect(0, 0, Frame.Size.Width, Frame.Size.Height));

			using (var context = UIGraphics.GetCurrentContext ())
			{

				context.MoveTo(lastPoint.X, lastPoint.Y);
				context.AddLineToPoint(currentPoint.X,currentPoint.Y);
				context.SetLineCap (CGLineCap.Round);
				context.SetLineWidth (brush);
				context.SetStrokeColor (PaintColor.CGColor);
				context.SetBlendMode (CGBlendMode.Normal);
				context.StrokePath ();


			}
			tempDrawImage.Image = UIGraphics.GetImageFromCurrentImageContext ();
			tempDrawImage.Alpha = opacity;
			UIGraphics.EndImageContext ();
			lastPoint = currentPoint;
		}

		public override void TouchesEnded (Foundation.NSSet touches, UIEvent evt)
		{

			if(!swiped) {

				UIGraphics.BeginImageContext(Frame.Size);
				tempDrawImage.Image.Draw (new CGRect(0, 0, Frame.Size.Width, Frame.Size.Height));

				using (var context = UIGraphics.GetCurrentContext ())
				{


					context.SetLineCap (CGLineCap.Round);
					context.SetLineWidth (brush);
					context.SetStrokeColor(PaintColor.CGColor);
					context.MoveTo(lastPoint.X, lastPoint.Y);
					context.AddLineToPoint(lastPoint.X, lastPoint.Y);
					context.StrokePath ();
					context.Flush ();
					tempDrawImage.Image = UIGraphics.GetImageFromCurrentImageContext ();
					UIGraphics.EndImageContext();

				}
			}


			UIGraphics.BeginImageContext(mainImage.Frame.Size);
			mainImage.Image.Draw(new CGRect(0, 0, Frame.Size.Width, Frame.Size.Height), CGBlendMode.Normal, 1.0f);
			tempDrawImage.Image.Draw (new CGRect(0, 0, Frame.Size.Width, Frame.Size.Height), CGBlendMode.Normal, opacity);
			mainImage.Image = UIGraphics.GetImageFromCurrentImageContext ();
			//tempDrawImage.Image = CreateImageFromColor ();
			UIGraphics.EndImageContext();

		}

		public UIImage CreateImageFromColor()
		{
			var imageSize = new SizeF(30, 30);
			var imageSizeRectF = new RectangleF(0, 0, 30, 30);
			UIGraphics.BeginImageContextWithOptions(imageSize, false, 0);
			var context = UIGraphics.GetCurrentContext();
			var color = new UIColor(255.0f,255.0f,255.0f,0.0f).CGColor;
			context.SetFillColor(color);
			context.FillRect(imageSizeRectF);
			var image = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();
			return image;
		}
	}
}


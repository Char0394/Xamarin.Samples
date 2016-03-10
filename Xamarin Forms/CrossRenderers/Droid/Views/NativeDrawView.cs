using System;
using Android.Views;
using Android.Content;
using Android.Util;
using Android.Graphics;

namespace CrossRenderers.Droid
{
	public class NativeDrawView : View
	{
		//drawing path
		private Path drawPath;
		//drawing and canvas paint
		private Paint drawPaint, canvasPaint;

		public Color PaintColor { get { return drawPaint?.Color??Color.Black; } set {drawPaint.Color = value; } }
		//canvas
		private Canvas drawCanvas;
		//canvas bitmap
		private Bitmap canvasBitmap;

		public NativeDrawView(Context context, IAttributeSet attrs,int defStyle): base(context, attrs, defStyle)
		{
			Initialize ();
		}

		public NativeDrawView(Context context, IAttributeSet attrs): base(context, attrs)
		{
			Initialize ();
		}

		public NativeDrawView(Context context): base(context)
		{
			Initialize ();
		}



		void Initialize()
		{
			drawPath = new Path();
			drawPaint = new Paint();
			drawPaint.Color =  Color.Black;
			drawPaint.AntiAlias=true;
			drawPaint.StrokeWidth =20;
			drawPaint.SetStyle(Paint.Style.Stroke);
			drawPaint.StrokeJoin = Paint.Join.Round;
			drawPaint.StrokeCap = Paint.Cap.Round;
			canvasPaint = new Paint(PaintFlags.Dither);
			DrawingCacheEnabled = true;
		}
		protected override void OnSizeChanged (int w, int h, int oldw, int oldh)
		{
			base.OnSizeChanged (w, h, oldw, oldh);
			canvasBitmap = Bitmap.CreateBitmap(w, h, Bitmap.Config.Argb8888);
		}

		protected override void OnDraw (Canvas canvas)
		{
			
			drawCanvas = canvas;
			canvas.DrawBitmap(canvasBitmap, 0, 0, canvasPaint);
			canvas.DrawPath(drawPath, drawPaint);
		}

		public override bool OnTouchEvent (Android.Views.MotionEvent e)
		{
			var touchX = e.GetX();
			var touchY = e.GetY();
			switch (e.Action) 
			{
				case MotionEventActions.Down:
					drawPath.MoveTo(touchX, touchY);
					break;
				case MotionEventActions.Move:
					drawPath.LineTo(touchX, touchY);
					break;
				default:
					return false;
			}
			Invalidate();
			return true;
		}
	}
}


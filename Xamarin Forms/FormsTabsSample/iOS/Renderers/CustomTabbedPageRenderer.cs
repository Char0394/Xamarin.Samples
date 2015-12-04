using System;
using Xamarin.Forms;
using FormsTabsSample;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using System.Collections.Generic;

[assembly: ExportRenderer(typeof(PrettyTabbedPage), typeof(FormsTabsSample.iOS.CustomTabbedPageRenderer))]
namespace FormsTabsSample.iOS
{
	public class CustomTabbedPageRenderer : TabbedRenderer
	{
		IList<string> ImageIcons;

		UISwipeGestureRecognizer _leftSwipeGesture;
		UISwipeGestureRecognizer _rightSwipeGesture;

		public UISwipeGestureRecognizer LeftSwipeGesture {
			get {
				if (_leftSwipeGesture == null) {
					_leftSwipeGesture = new UISwipeGestureRecognizer(LeftSwipeGestureTriggered);
					_leftSwipeGesture.Direction = UISwipeGestureRecognizerDirection.Left;
					_leftSwipeGesture.NumberOfTouchesRequired = 1;


				}
				return _leftSwipeGesture;
			}
		}


		public UISwipeGestureRecognizer RightSwipeGesture {
			get {
				if (_rightSwipeGesture == null) {
					_rightSwipeGesture = new UISwipeGestureRecognizer(RightSwipeGestureTriggered);
					_rightSwipeGesture.Direction = UISwipeGestureRecognizerDirection.Right;
					_rightSwipeGesture.NumberOfTouchesRequired = 1;


				}
				return _rightSwipeGesture;
			}
		}
		protected override void OnElementChanged (VisualElementChangedEventArgs e)
		{
			base.OnElementChanged (e);

		

		}

		public override void WillBeginCustomizingItems (UITabBar tabbar, UITabBarItem[] items)
		{
			base.WillBeginCustomizingItems (tabbar, items);
			Console.WriteLine (this.Tabbed);
		}
	
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.View.AddGestureRecognizer(LeftSwipeGesture);
			this.View.AddGestureRecognizer(RightSwipeGesture);

		}
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
	
			for(int idx=0;idx<Tabbed.Children.Count;idx++) 
			{
				var page = Tabbed.Children [idx];

				if(page is TabPage)
				{
					var tabPage = (TabPage)page;

					if (tabPage.SelectedIcon != null) 
					{
						ViewControllers[idx].TabBarItem.SelectedImage=UIImage.FromBundle(tabPage.SelectedIcon.File);
					}

					if (!((PrettyTabbedPage)Tabbed).ShowTitles) 
					{
						
						ViewControllers [idx].Title = string.Empty;

					} else 
					{
						ViewControllers [idx].Title = tabPage.Title;

					}

				}
			}


		
		}

		void LeftSwipeGestureTriggered()
		{
			if (this.SelectedIndex < (this.ViewControllers.Length-1)) 
			{
				this.SelectedIndex++;
				this.Tabbed.CurrentPage = this.Tabbed.Children [(int)this.SelectedIndex];
			}
		}

		void RightSwipeGestureTriggered()
		{
			if (this.SelectedIndex > 0) 
			{
				this.SelectedIndex--;
				this.Tabbed.CurrentPage = this.Tabbed.Children [(int)this.SelectedIndex];
			}
		}


		
	}
}


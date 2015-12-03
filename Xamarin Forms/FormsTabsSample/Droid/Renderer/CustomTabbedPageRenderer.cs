using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;
using Android.Support.V7.App;
using Android.Widget;
using Android.Graphics;
using Android.Graphics.Drawables;
using FormsTabsSample;
using Android.App;
using Android.Support.Design.Widget;
using Android.Support.V4.View;

[assembly: ExportRenderer(typeof(MyTabbedPage), typeof(FormsTabsSample.Droid.CustomTabbedPageRenderer))]
namespace FormsTabsSample.Droid
{
	public class CustomTabbedPageRenderer : TabbedPageRenderer
	{
		ViewPager viewPager;
		TabLayout tabs;
		MyTabbedPage tabbedPage;
		bool firstTime = true;
		protected override void OnElementChanged (ElementChangedEventArgs<TabbedPage> e)
		{
			base.OnElementChanged (e);


			 tabbedPage = e.NewElement as MyTabbedPage;

			 viewPager = (ViewPager)GetChildAt (0);
		
			tabs = this.FindViewById<TabLayout> (Resource.Id.sliding_tabs);

			tabs.TabSelected+=(s,a)=>{



				var page=tabbedPage.Children [a.Tab.Position];

				if(page is TabPage)
				{
					var tPage =(TabPage)page;

					SetTab(a.Tab,tPage.SelectedIcon.File);

				}

				viewPager.SetCurrentItem(a.Tab.Position,false);


			};

			tabs.TabUnselected += (s, a) => {

				var page=tabbedPage.Children [a.Tab.Position];

				if(page is TabPage)
				{
					SetTab(a.Tab,page.Icon.File);
				}

			};
		}

		protected override void DispatchDraw (Canvas canvas)
		{
			base.DispatchDraw (canvas);
			if (!firstTime)
				return;
			
			for(int i = 0; i< tabs.TabCount; i++)
			{
				var tab = tabs.GetTabAt (i);
				var page = tabbedPage.Children [tab.Position];

				if (page is TabPage) {

					var tPage = (TabPage)page;

					SetTab (tab, (tabs.SelectedTabPosition == tab.Position) ? tPage.SelectedIcon.File : tPage.Icon.File);

				} else 
				{
					SetTab (tab, page.Icon.File);

				}

				if (!tabbedPage.ShowTitles) 
				{
					tab.SetText (string.Empty);
				}

			}
			firstTime = false;


		}

		void SetTab(Android.Support.Design.Widget.TabLayout.Tab tab,string name)
		{
			try
			{

			    int id = Resources.GetIdentifier (name, "drawable", Context.PackageName); 

		    	tab.SetIcon (id);

			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.StackTrace);
			}
		}
	


	}
}


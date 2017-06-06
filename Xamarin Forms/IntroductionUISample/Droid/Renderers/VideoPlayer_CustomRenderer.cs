using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content.Res;
using Android.Media;
using IntroductionUISample;
using IntroductionUISample.Droid;

[assembly: ExportRenderer(typeof(VideoPlayerView), typeof(VideoPlayer_CustomRenderer))]
namespace IntroductionUISample.Droid
{
	public class VideoPlayer_CustomRenderer : ViewRenderer, ISurfaceHolderCallback
	{
		//Create views globally so they can be referenced in OnLayout override
		VideoView videoView;
		//Android.Widget.Button playButton;
		global::Android.Views.View view;
		MediaPlayer player;

		int width, height;

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
		{
			base.OnElementChanged(e);

			//Get LayoutInflater and inflate from axml
			//Important note, this project utilizes a layout-land folder in the Resources folder
			//Android will use this folder with layout files for Landscape Orientations
			//This is why we don't have to worry about the layout of the play button, it doesn't exist in landscape layout file!!! 
			var activity = Context as Activity;
			var viewHolder = activity.LayoutInflater.Inflate(Droid.Resource.Layout.Main, this, false);
			view = viewHolder;
			AddView(view);

			//Get and set Views
			videoView = FindViewById<VideoView>(Droid.Resource.Id.SampleVideoView);
			play("intro.mp4");

		}

		protected override void OnLayout(bool changed, int l, int t, int r, int b)
		{
			base.OnLayout(changed, l, t, r, b);

			//Calculate width and height for easier reading
			width = r - l;
			height = b - t;

			//If in Landscape, we want to make sure we are in full screen
			if (Resources.Configuration.Orientation == Android.Content.Res.Orientation.Landscape)
			{
				//Landscape Orientation
				view.Layout(0, 0, width, height);
				videoView.Layout(0, 0, width, height);
				//You must also set the size of the videoView holder, or else full screen won't work
				//If the layout of the videoView increases, that doesn't mean the holder that holds the video automaticall increases
				videoView.Holder.SetFixedSize(width, height);
			}
			else
			{
				//Portrait Orientation, just layout everything nomally
				view.Layout(0, 0, width, height);
				videoView.Layout(0, 0, width, height);
				//Still need to do this to ensure when you rotate from Landscape back to Portrait, the values are reset
				videoView.Holder.SetFixedSize(width, height);
				//playButton.Layout (0, height - 150, width, height);
			}
		}

		protected override void OnConfigurationChanged(Android.Content.Res.Configuration newConfig)
		{
			base.OnConfigurationChanged(newConfig);

			//Hide the Status Bar when in full screen. 
			if (newConfig.Orientation == Android.Content.Res.Orientation.Landscape)
			{
				StatusBarHelper.DecorView.SystemUiVisibility = StatusBarVisibility.Hidden;
				//If you have an ActionBar, uncomment the line below
				//StatusBarHelper.AppActionBar.Hide ();
			}
			else
			{
				StatusBarHelper.DecorView.SystemUiVisibility = StatusBarVisibility.Visible;
				//If you have an ActionBar, uncomment the line below
				//StatusBarHelper.AppActionBar.Show ();
			}
		}

		void play(string fullPath)
		{
			ISurfaceHolder holder = videoView.Holder;
			holder.SetType(SurfaceType.PushBuffers);
			holder.AddCallback(this);
			player = new MediaPlayer();
			player.Looping = true;
			Android.Content.Res.AssetFileDescriptor afd = this.Context.Assets.OpenFd(fullPath);
			if (afd != null)
			{
				player.SetDataSource(afd.FileDescriptor, afd.StartOffset, afd.Length);
				player.Prepare();
				player.Start();
			}
		}

		public void SurfaceCreated(ISurfaceHolder holder)
		{
			Console.WriteLine("SurfaceCreated");
			player.SetDisplay(holder);
		}
		public void SurfaceDestroyed(ISurfaceHolder holder)
		{
			Console.WriteLine("SurfaceDestroyed");
		}
		public void SurfaceChanged(ISurfaceHolder holder, Android.Graphics.Format format, int w, int h)
		{
			Console.WriteLine("SurfaceChanged");
		}
		public void OnPrepared(MediaPlayer player)
		{

		}
	}
}
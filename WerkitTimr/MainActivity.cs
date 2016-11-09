// BOOKMARK YOU were changed the saved_timer_activity to MainTImer and are going to create a list of saved timers. To Implement and save timer you need to learn SQLite data acees google it
using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;

namespace WerkitTimr
{
	[Activity(Label = "Saved Timers", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		//int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button SavedTimerButton = FindViewById<Button>(Resource.Id.button1);
			Button CreateButton = FindViewById<Button>(Resource.Id.button2);

			SavedTimerButton.Click += (object sender, EventArgs e) =>
			{
				var intent = new Intent(this, typeof(MainTimerActivity));
				StartActivity(intent);

			};


			CreateButton.Click += (object sender, EventArgs e) =>
			{
				var intent = new Intent(this, typeof(CreateTimerActivity));
				StartActivity(intent);

			};

		}


	}
}


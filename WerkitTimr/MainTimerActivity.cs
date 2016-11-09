
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
//using Android.OS.CountDownTimer;



namespace WerkitTimr
{
	[Activity(Label = "Saved Timer")]

	public class MainTimerActivity : Activity
	{
		public static int seconds, rounds, debug;
		public static int count, progresscounter, roundscounter;

		public static Timer timeboy;
		TextView TimerText;
		Button StopButton, ResetButton;
		ProgressBar ProgressBar;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Saved_Timer);

			// Create your application here
			TimerText = FindViewById<TextView>(Resource.Id.TimerText);
			StopButton = FindViewById<Button>(Resource.Id.StopButton);
			ResetButton = FindViewById<Button>(Resource.Id.ResetButton);
			ProgressBar = FindViewById<ProgressBar>(Resource.Id.ProgressBar);

			var localtimers = Application.Context.GetSharedPreferences("Timer", FileCreationMode.Private);
			string StringSeconds = localtimers.GetString("Seconds", null);
			string StringRounds = localtimers.GetString("Rounds", null);

			/*timeboy = new Timer();
			timeboy.Interval = 1000; //1 second interval
			timeboy.Elapsed += Timeboy_Elapsed;
			//timeboy.Start();*/

			StopButton.Click += StopButton_Click;
			ResetButton.Click += ResetButton_Click;

			int.TryParse(StringSeconds, out seconds);
			int.TryParse(StringRounds, out rounds);

			/*ProgressBar.Max = seconds;
			count = seconds;

			if (count <= 9)
				TimerText.Text = "00:0" + count;
			else if (count > 9)
				TimerText.Text = "00:" + count;
			else
				TimerText.Text = "00:" + count;*/
			TimeBoyMain();


		}

		void TimeBoyMain()
		{

			timeboy = new Timer();
			timeboy.Interval = 1000; //1 second interval
			timeboy.Elapsed += Timeboy_Elapsed;
			//timeboy.Start();

			ProgressBar.Max = seconds;
			progresscounter = 0;
			count = seconds;
			roundscounter++;

			if (count <= 9)
				TimerText.Text = "00:0" + count;
			else if (count > 9)
				TimerText.Text = "00:" + count;
			else
				TimerText.Text = "00:" + count;

		}

		void Timeboy_Elapsed(object sender, ElapsedEventArgs e)
		{

			{

				if (count != 0)
				{

					RunOnUiThread(() =>
					{
						Toast.MakeText(this, "Round " + roundscounter, ToastLength.Short).Show();
						ProgressBar.Progress = progresscounter;

						if (count <= 9)
							TimerText.Text = "00:0" + count;
						else
							TimerText.Text = "00:" + count;

					});
					progresscounter++;
					count--;

				}
				else if (count == 0)
				{
					RunOnUiThread(() =>
					{

						//Toast.MakeText(this, "Excercise Complete", ToastLength.Short).Show();
						TimerText.Text = "00:0" + count;
						timeboy.Stop();
						//debug++;

						if (roundscounter != rounds)
						{
							ProgressBar.Progress = 0;
							TimeBoyMain();
							timeboy.Start();
							//Reset();
							debug++;

						}
						else if (roundscounter == rounds)
						{
							timeboy.Stop();
							roundscounter = 0;
						}


					});

				}


			}
		}

		void Reset()
		{
			if (roundscounter != rounds)
			{
				TimeBoyMain();
				timeboy.Start();
			}
			else if (roundscounter == rounds)
			{
				timeboy.Stop();
			}
		}

		void StopButton_Click(object sender, EventArgs e)
		{
			timeboy.Stop();

		}

		void ResetButton_Click(object sender, EventArgs e)
		{
			timeboy.Start();
		}

		protected override void OnPause()
		{
			base.OnPause();
			timeboy.Stop();

		}

	}


}

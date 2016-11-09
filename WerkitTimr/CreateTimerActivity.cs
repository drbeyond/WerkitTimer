using System;
using WerkitTimer;
using Android.App;
using Android.OS;
using Android.Widget;
using System.Collections.Generic;
using Android.Util;
using Android.Content;

namespace WerkitTimr
{
	[Activity(Label = "Create New Timer")]
	public class CreateTimerActivity : Activity
	{
		//public static string selecteditem;
		//public static string roundsitem, timerlabel;

		ListView lstData;
		List<Person> lstSource = new List<Person>();
		DataBase db;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.Create_Timer);
			db = new DataBase();
			db.createDataBase();
			string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
			Log.Info("DB_PATH", folder);

			lstData = FindViewById<ListView>(Resource.Id.listView);

			Button savebutton = FindViewById<Button>(Resource.Id.SaveButton);
			EditText TimerLabel = FindViewById<EditText>(Resource.Id.TimerLabel);
			var edtSeconds = FindViewById<EditText>(Resource.Id.secondselect);
			var edtRounds = FindViewById<EditText>(Resource.Id.roundselect);

			LoadData();


			savebutton.Click += (object sender, EventArgs ee) =>
			{
				Person person = new Person()
				{
					Label = TimerLabel.Text,
					Seconds = edtSeconds.Text,
					Rounds = edtRounds.Text,

				};
				db.insertIntoTablePerson(person);
				LoadData();
			};

			lstData.ItemClick += (s, e) =>
			{
				//Set background for selected item
				/*for (int i = 0; i < lstData.Count; i++)
				{
					if (e.Position == i)
						lstData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.DarkGray);
					else
						lstData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);

				}*/

				var txtLabel = e.View.FindViewById<TextView>(Resource.Id.textView1);
				var txtSeconds = e.View.FindViewById<TextView>(Resource.Id.textView2);
				var txtRounds = e.View.FindViewById<TextView>(Resource.Id.textView3);

				TimerLabel.Text = txtLabel.Text;
				//TimerLabel.Tag = e.Id;

				edtSeconds.Text = txtSeconds.Text;

				edtRounds.Text = txtRounds.Text;

				var prefs = Application.Context.GetSharedPreferences("Timer", FileCreationMode.Private);
				var prefEditor = prefs.Edit();
				prefEditor.PutString("Seconds", edtSeconds.Text);
				prefEditor.PutString("Rounds", edtRounds.Text);
				prefEditor.Commit();

				var intent = new Intent(this, typeof(MainTimerActivity));
				StartActivity(intent);

			};
		}

		private void LoadData()
		{
			lstSource = db.selectTablePerson();
			var adapter = new ListViewAdapter(this, lstSource);
			lstData.Adapter = adapter;
		}
	}
}

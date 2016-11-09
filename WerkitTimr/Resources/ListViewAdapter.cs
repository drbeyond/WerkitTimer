using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WerkitTimr;
using Java.Lang;

namespace WerkitTimer
{
	public class ViewHolder : Java.Lang.Object
	{
		public TextView txtLabel { get; set; }
		public TextView txtSeconds { get; set; }
		public TextView txtRounds { get; set; }
	}
	public class ListViewAdapter : BaseAdapter
	{

		private Activity activity;
		private List<Person> lstPerson;

		public ListViewAdapter(Activity activity, List<Person> lstPerson)
		{
			this.activity = activity;
			this.lstPerson = lstPerson;
		}

		public override int Count
		{
			get
			{
				return lstPerson.Count;
			}
		}

		public override Java.Lang.Object GetItem(int position)
		{
			return null;
		}

		public override long GetItemId(int position)
		{
			return lstPerson[position].id;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.list_view_dataTemplate, parent, false);

			var txtLabel = view.FindViewById<TextView>(Resource.Id.textView1);
			var txtSeonds = view.FindViewById<TextView>(Resource.Id.textView2);
			var txtRounds = view.FindViewById<TextView>(Resource.Id.textView3);

			txtLabel.Text = lstPerson[position].Label;
			txtSeonds.Text = "" + lstPerson[position].Seconds;
			txtRounds.Text = lstPerson[position].Rounds;

			return view;
		}
	}
}
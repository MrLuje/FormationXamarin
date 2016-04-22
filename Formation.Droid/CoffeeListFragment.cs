
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using FormationVDO;

namespace Formation.Droid
{
	public class CoffeeListFragment : Fragment
	{
		private CoffeeListViewModel viewModel;
		private bool isTypeList;
		private CoffeeListAdapter adapter;

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			isTypeList = this.Arguments.GetBoolean("isList");
			viewModel = App.ServiceLocator.CoffeeListViewModel;
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			var view = inflater.Inflate(Resource.Layout.fragmentCoffeeList, container, false);
			var collection = (isTypeList ? viewModel.AllCoffees : viewModel.FavoriteCoffees);
			adapter = new CoffeeListAdapter (collection);
			var coffeeListView = view.FindViewById<ListView> (Resource.Id.listView);

			collection.CollectionChanged += (sender, e) => adapter.NotifyDataSetChanged ();

			coffeeListView.FastScrollEnabled = true;
			coffeeListView.FastScrollAlwaysVisible = true;

			coffeeListView.Adapter = adapter;
			coffeeListView.ItemClick += CoffeeListView_ItemClick;

			return view;
		}

		void CoffeeListView_ItemClick (object sender, AdapterView.ItemClickEventArgs e)
		{
			App.ServiceLocator.NavigationService.CurrentParameter = this.adapter [e.Position];
			this.Activity.StartActivity(typeof(CoffeeDetailActivity));
		}
	}
}


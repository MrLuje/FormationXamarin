
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
using FormationVDO;
using Android.Support.V7.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace Formation.Droid
{
	[Activity (Label = "CoffeeDetailActivity")]			
	public class CoffeeDetailActivity : AppCompatActivity
	{
		CoffeeViewModel viewModel = App.ServiceLocator.CoffeeViewModel;

		protected async override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView (Resource.Layout.activity_coffeeDetail);
				
			this.viewModel.Initialize ();

			var btnFavorite = FindViewById<Button> (Resource.Id.btnFavorite);
			var isFavorite = await viewModel.IsFavorite ();

			var coffeeNameView = FindViewById<TextView> (Resource.Id.tvCoffeeName);
			coffeeNameView.Text = this.viewModel.CoffeeShop.Name;

			btnFavorite.Text = Resources.GetString(isFavorite ? Resource.String.removeFavorite : Resource.String.addFavorite);
			btnFavorite.Click += BtnFavorite_Click;

			var mapFrag = FragmentManager.FindFragmentById<MapFragment>(Resource.Id.myMap);
			var map = mapFrag.Map;

			if (map == null)
				return;

			this.viewModel.MapService = new MapService (map, this);
			this.viewModel.DisplayCoffee ();
		}

		async void BtnFavorite_Click (object sender, EventArgs e)
		{
			if (await viewModel.IsFavorite ())
				await this.viewModel.RemoveFromFavorite ();
			else
				await this.viewModel.AddToFavorite ();

			await App.ServiceLocator.CoffeeListViewModel.Initialize(forceRefresh: true);

			this.Finish();
		}
	}
}


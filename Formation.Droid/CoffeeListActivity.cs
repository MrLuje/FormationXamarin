
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
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Graphics.Drawables;
using FormationVDO;

namespace Formation.Droid
{
	[Activity (Label = "CoffeeListActivity")]			
	public class CoffeeListActivity : AppCompatActivity
	{
		private FragmentTabHost mTabHost;

		protected async override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your application here
			SetContentView (Resource.Layout.CoffeeList);

			mTabHost = FindViewById<FragmentTabHost>(Android.Resource.Id.TabHost);
			mTabHost.Setup (this, this.SupportFragmentManager, Android.Resource.Id.TabContent);

			var icon = Resources.GetDrawable (Android.Resource.Drawable.IcMenuMore);
			var iconFav = Resources.GetDrawable (Android.Resource.Drawable.IcMenuMyPlaces);

			var bundleList = new Bundle ();
			bundleList.PutBoolean ("isList", true);

			mTabHost.AddTab (mTabHost.NewTabSpec ("coffeeList")
									 .SetIndicator("All", icon), 
							 Java.Lang.Class.FromType(typeof(CoffeeListFragment)), 
				bundleList);

			var bundleFav = new Bundle ();
			bundleFav.PutBoolean ("isList", false);

			mTabHost.AddTab (mTabHost.NewTabSpec ("coffeeFavorite")
				.SetIndicator("Favorites", iconFav), 
				Java.Lang.Class.FromType(typeof(CoffeeListFragment)), 
				bundleFav);

			var viewModel = App.ServiceLocator.CoffeeListViewModel;
			await viewModel.Initialize ();
		}
	}
}


using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.App;

namespace Formation.Droid
{
	[Activity (Label = "Formation.Droid", MainLauncher = true, Icon = "@mipmap/icon")]
	public class LandingActivity : AppCompatActivity
	{
		int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.monBoBtn);

			this.SupportActionBar.Subtitle = "Because we love coffees !";

			button.Click += (o, e) => {
				StartActivity(typeof(CoffeeListActivity));
			};
		}
	}


}
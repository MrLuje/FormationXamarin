using System;

using Xamarin.Forms;
using FormationVDO.Infrastructure;

namespace Formation.Forms
{
	public class App : Application
	{
		public static IServiceLocator ServiceLocator = DependencyService.Get<IServiceLocator> ();

		public App ()
		{
			MainPage = new NavigationPage( new Landing ());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}


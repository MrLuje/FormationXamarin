using System;
using Android.App;
using Android.Runtime;
using FormationVDO.Infrastructure;

namespace Formation.Droid
{
	[Application]
	public class App : Application
	{
		public static IServiceLocator ServiceLocator = new ServiceLocator();

		public App (IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
			
		}

		public override void OnCreate ()
		{
			base.OnCreate ();
		}

		public override void OnTerminate ()
		{
			base.OnTerminate ();
		}
	}
}


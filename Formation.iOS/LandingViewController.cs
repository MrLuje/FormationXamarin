using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using FormationVDO;

namespace Formation.iOS
{
	partial class LandingViewController : UIViewController
	{
		public CoffeeListViewModel ViewModel { get { return AppDelegate.Locator.CoffeeListViewModel; } }

		public LandingViewController (IntPtr handle) : base (handle)
		{
		}

		public async override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.loader.StartAnimating ();

			this.btnContinue.Enabled = false;
			await this.ViewModel.Initialize ();
			this.btnContinue.Enabled = true;

			this.loader.StopAnimating ();
		}
	}
}

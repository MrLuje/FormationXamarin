using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using FormationVDO;
using System.Linq;

namespace Formation.iOS
{
	partial class CoffeeController : UIViewController
	{
		public CoffeeListViewModel ViewModel {
			get;
			private set;
		}

		public CoffeeController (IntPtr handle) : base (handle)
		{
			this.ViewModel = new CoffeeListViewModel (null, null);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.ViewModel.Initialize ();

			LoadViewComponents ();
		}

		void LoadViewComponents ()
		{
			//lblCoffeeName.Text = this.ViewModel.AllCoffees.First ().Name;
			lblCoffeeName.Text = "oiu&";
		}
	}
}

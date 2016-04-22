using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using FormationVDO;
using MapKit;
using System.Threading.Tasks;

namespace Formation.iOS
{
	partial class CoffeeDetailController : UIViewController
	{
		public CoffeeViewModel ViewModel { get { return AppDelegate.Locator.CoffeeViewModel; } }

		public CoffeeDetailController (IntPtr handle) : base (handle)
		{
		}

		public override async void ViewDidLoad ()
		{
			this.ViewModel.Initialize ();

			base.ViewDidLoad ();

			this.ViewModel.MapService = new MapService (this.mpLocation);
			this.ViewModel.DisplayCoffee ();

			this.lblCoffeeName.Text = this.ViewModel.CoffeeShop.Name;

			var btnTxt = await this.ViewModel.IsFavorite() ? 
				"Enlever des favoris" :
				"Ajouter aux favoris";
			
			this.btnFav.SetTitle(btnTxt, UIControlState.Normal);
		}

		async partial void BtnFav_TouchUpInside (UIButton sender)
		{
			this.btnFav.Enabled = false;

			if(await this.ViewModel.IsFavorite())
				await this.ViewModel.RemoveFromFavorite();
			else
				await this.ViewModel.AddToFavorite();

			await AppDelegate.Locator.CoffeeListViewModel.Initialize(forceRefresh: true);

			this.NavigationController.PopViewController(true);
		}
	}
}

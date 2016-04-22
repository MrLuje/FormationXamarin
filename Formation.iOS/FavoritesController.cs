using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using FormationVDO;

namespace Formation.iOS
{
	partial class FavoritesController : UITableViewController
	{
		public CoffeeListViewModel ViewModel { get { return AppDelegate.Locator.CoffeeListViewModel; } }
		public INavigationService NavigationService { get { return AppDelegate.Locator.NavigationService; } }
		public CoffeeListSource source;

		public FavoritesController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			source = new CoffeeListSource (this.ViewModel.FavoriteCoffees);

			this.TableView.Source = source;
			this.TableView.Delegate = new CoffeeDelegate (this);

			base.ViewDidLoad ();

			this.TableView.ReloadData ();
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			this.PerformSegue ("sgShowFav", indexPath);
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			var coffee = this.source.GetCoffeeForIndex((NSIndexPath)sender);
			this.NavigationService.CurrentParameter = coffee;
		}
	}
}

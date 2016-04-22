using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using FormationVDO;
using System.Threading.Tasks;

namespace Formation.iOS
{
	partial class CoffeeListViewController : UITableViewController
	{
		public CoffeeListViewModel ViewModel { get { return AppDelegate.Locator.CoffeeListViewModel; } }
		public INavigationService NavigationService { get { return AppDelegate.Locator.NavigationService; } }
		public CoffeeListSource source;

		public CoffeeListViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			source = new CoffeeListSource (this.ViewModel.AllCoffees);

			this.TableView.Source = source;
			this.TableView.Delegate = new CoffeeDelegate (this);

			base.ViewDidLoad ();
		}

		public override void ViewWillAppear (bool animated)
		{
			this.TableView.ReloadData ();
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			this.PerformSegue ("sgShow", indexPath);
		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			var coffee = this.source.GetCoffeeForIndex((NSIndexPath)sender);
			this.NavigationService.CurrentParameter = coffee;
		}
	}
}

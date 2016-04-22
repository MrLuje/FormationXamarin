using System;
using UIKit;

namespace Formation.iOS
{
	public class CoffeeDelegate : UITableViewDelegate
	{
		UITableViewController ctrl;

		public CoffeeDelegate (UITableViewController ctrl)
		{
			this.ctrl = ctrl;
		}

		public override void RowSelected (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			this.ctrl.RowSelected (tableView, indexPath);
		}
	}
}


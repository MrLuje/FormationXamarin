using System;
using UIKit;
using FormationVDO;
using System.Collections.Generic;
using System.Linq;

namespace Formation.iOS
{
	public class CoffeeListSource : UITableViewSource
	{
		const string cellId = "my-coffee-cell";

		IEnumerable<CoffeeShop> coffees;

		public CoffeeListSource(IEnumerable<CoffeeShop> coffees){
			this.coffees = coffees.OrderBy(c => c.Name).ToList();

			var initial = this.coffees.Select (c => c.Name[0]).Distinct();
			this.letters = String.Join("", initial);

			new UITableView ();
		}

		public CoffeeShop GetCoffeeForIndex(Foundation.NSIndexPath indexPath)
		{
			var categ = this.letters [indexPath.Section].ToString();

			var coffee = this.coffees.Where(c => c.Name.StartsWith(categ))
				.ElementAt (indexPath.Row);

			return coffee;
		}

		#region implemented abstract members of UITableViewSource

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellId);

			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Subtitle, cellId);

			var coffee = GetCoffeeForIndex (indexPath);
			cell.TextLabel.Text = coffee.Name;
			cell.DetailTextLabel.Text = coffee.Address;

			return cell;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			var categ = this.letters.ElementAt ((int)section).ToString();
			var cnt = this.coffees.Where (c => c.Name.StartsWith (categ)).Count ();
			return cnt;
		}

	 	string letters = "";

		public override string TitleForHeader (UITableView tableView, nint section)
		{
			return letters.ElementAt((int)section).ToString();
		}
			
		public override void RowSelected (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			tableView.Delegate.RowSelected (tableView, indexPath);
		}

		public override nint NumberOfSections (UITableView tableView)
		{
			return this.letters.Count();
		}

		#endregion
	}
}


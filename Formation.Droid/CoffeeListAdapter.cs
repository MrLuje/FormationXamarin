using System;
using Android.Widget;
using FormationVDO;
using System.Collections.Generic;
using Android.Views;
using System.Linq;

namespace Formation.Droid
{
	public class CoffeeListAdapter : BaseAdapter<CoffeeShop>, ISectionIndexer
	{
		IList<CoffeeShop> coffees;
		List<string> letters;

		public CoffeeListAdapter (IList<CoffeeShop> coffees)
		{
			this.coffees = coffees;
			this.letters = new List<string> ();
		}

		public override void NotifyDataSetChanged ()
		{
			base.NotifyDataSetChanged ();

			this.letters = coffees.Select (c => c.Name[0].ToString())
								  .Distinct()
								  .OrderBy(c => c)
								  .ToList();
		}

		#region implemented abstract members of BaseAdapter

		public override long GetItemId (int position)
		{
			return 0;
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			if (convertView == null) {
				var inflater = LayoutInflater.FromContext(parent.Context);
				convertView = inflater.Inflate (Resource.Layout.ItemCoffeeShop, null);
			}

			var titleView = convertView.FindViewById<TextView> (Resource.Id.coffeeItemTitle);
			titleView.Text = this [position].Name;

			var subTitleView = convertView.FindViewById<TextView> (Resource.Id.coffeeItemSubtitle);
			subTitleView.Text = this [position].Address;

			return convertView;
		}

		public override int Count {
			get {
				return this.coffees.Count;
			}
		}

		#endregion

		public int GetPositionForSection (int sectionIndex)
		{
			var initial = this.letters[sectionIndex];
			var coffee = this.coffees.First (c => c.Name.StartsWith (initial));

			return this.coffees.IndexOf (coffee);
		}

		public int GetSectionForPosition (int position)
		{
			var initial = this.coffees [position].Name [0];
			return this.letters.IndexOf (initial.ToString());
		}

		public Java.Lang.Object[] GetSections ()
		{
			
			return this.letters.Select(c => new Java.Lang.String(c)).ToArray();
		}

		#region implemented abstract members of BaseAdapter

		public override CoffeeShop this [int index] {
			get {
				return this.coffees [index];
			}
		}

		#endregion
	}
}


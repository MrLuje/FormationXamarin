using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using FormationVDO;

namespace Formation.iOS
{
	partial class FavoriteController : UIViewController
	{
		public CoffeeListViewModel ViewModel { get { return AppDelegate.Locator.CoffeeListViewModel; } }

		public FavoriteController (IntPtr handle) : base (handle)
		{
			
		}
	}
}

// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Formation.iOS
{
	[Register ("CoffeeController")]
	partial class CoffeeController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblCoffeeName { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (lblCoffeeName != null) {
				lblCoffeeName.Dispose ();
				lblCoffeeName = null;
			}
		}
	}
}

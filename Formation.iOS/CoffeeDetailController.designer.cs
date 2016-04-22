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
	[Register ("CoffeeDetailController")]
	partial class CoffeeDetailController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnFav { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblCoffeeName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MapKit.MKMapView mpLocation { get; set; }

		[Action ("BtnFav_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void BtnFav_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnFav != null) {
				btnFav.Dispose ();
				btnFav = null;
			}
			if (lblCoffeeName != null) {
				lblCoffeeName.Dispose ();
				lblCoffeeName = null;
			}
			if (mpLocation != null) {
				mpLocation.Dispose ();
				mpLocation = null;
			}
		}
	}
}

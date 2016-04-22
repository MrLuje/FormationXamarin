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
	[Register ("LandingViewController")]
	partial class LandingViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnContinue { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIActivityIndicatorView loader { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnContinue != null) {
				btnContinue.Dispose ();
				btnContinue = null;
			}
			if (loader != null) {
				loader.Dispose ();
				loader = null;
			}
		}
	}
}

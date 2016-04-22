using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FormationVDO;

namespace Formation.Forms
{
	public partial class Landing : ContentPage
	{
		public Landing ()
		{
			InitializeComponent ();

			this.Title = "Coffee";

			var vm = new LandingViewModel ();

			this.btnContinue.Clicked += async (sender, e) => {
				await this.Navigation.PushAsync (new CoffeeList ());
				this.Navigation.RemovePage (this);
			};

			this.BindingContext = vm;

		}
	}
}


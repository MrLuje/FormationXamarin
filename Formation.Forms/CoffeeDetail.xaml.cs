using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FormationVDO;
using Xamarin.Forms.Maps;

namespace Formation.Forms
{
	public partial class CoffeeDetail : ContentPage
	{
		CoffeeViewModel ViewModel = App.ServiceLocator.CoffeeViewModel;

		public CoffeeDetail ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

		 	this.ViewModel.Initialize ();

			var mapService = DependencyService.Get<IMapService> (DependencyFetchTarget.GlobalInstance);
			mapService.SetMap (this.MyMap);

			this.ViewModel.MapService = mapService;
			this.ViewModel.DisplayCoffee ();

			this.BindingContext = this.ViewModel.CoffeeShop;
		}
	}
}


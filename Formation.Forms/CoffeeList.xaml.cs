using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FormationVDO;

namespace Formation.Forms
{
	public partial class CoffeeList : ContentPage
	{
		public CoffeeListViewModel ViewModel = App.ServiceLocator.CoffeeListViewModel;
			
		public CoffeeList ()
		{
			InitializeComponent ();

			this.Title = "I love coffees";
			this.BindingContext = this.ViewModel;
		}

		async void Lst_ItemTapped (object sender, ItemTappedEventArgs e)
		{
			App.ServiceLocator.NavigationService.CurrentParameter = (CoffeeShop)e.Item;
			await this.Navigation.PushAsync (new CoffeeDetail ());
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			await this.ViewModel.Initialize ();
		}
	}
}


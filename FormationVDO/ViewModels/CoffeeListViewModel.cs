using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using System.Collections.ObjectModel;

namespace FormationVDO
{
	public class CoffeeListViewModel
	{
		public ObservableCollection<CoffeeShop> AllCoffees {
			get;
			private set;
		}
		public ObservableCollection<CoffeeShop> FavoriteCoffees {
			get;
			private set;
		}

		ICoffeeService coffeeService;
		IFavoriteService favoriteService;

		public CoffeeListViewModel (ICoffeeService coffeeService, IFavoriteService favoriteService)
		{
			this.favoriteService = favoriteService;
			this.coffeeService = coffeeService;
			this.AllCoffees = new ObservableCollection<CoffeeShop> ();
			this.FavoriteCoffees = new ObservableCollection<CoffeeShop> ();
		}

		private SemaphoreSlim sema = new SemaphoreSlim(1, 1);

		public async Task Initialize(bool forceRefresh = false){

			await sema.WaitAsync ();

			if (this.AllCoffees.Any () && !forceRefresh)
				return;

			this.AllCoffees.Clear();
			this.FavoriteCoffees.Clear();

			var favorites = await favoriteService.GetFavorites ();
			var coffees = (await coffeeService.GetAll ()).OrderBy(c => c.Name);

			foreach (var favorite in favorites) {
				this.FavoriteCoffees.Add (coffees.Single(c => c.Id == favorite ));
			}

			foreach (var coffee in coffees) {
				this.AllCoffees.Add (coffee);
			}

			sema.Release ();
		}
	}
}


using System;
using System.Threading.Tasks;
using System.Linq;

namespace FormationVDO
{
	public class CoffeeViewModel
	{
		IFavoriteService favoriteService;
		public CoffeeShop CoffeeShop { get; set; }
		INavigationService navigationService;
		public IMapService MapService { get; set;}

		public CoffeeViewModel (IFavoriteService favoriteService, INavigationService navigationService)
		{
			this.navigationService = navigationService;
			this.favoriteService = favoriteService;
		}

		public void Initialize()
		{
			this.CoffeeShop = this.navigationService.CurrentParameter;

		}

		public void DisplayCoffee(){
			this.MapService.Configure ()
						   .ShowCoffee (this.CoffeeShop);
		}

		public async Task AddToFavorite()
		{
			await this.favoriteService.AddToFavorite (this.CoffeeShop.Id);
		}

		public async Task RemoveFromFavorite(){
			await this.favoriteService.RemoveFromFavorite (this.CoffeeShop.Id);
		}

		public async Task<bool> IsFavorite(){
			if (this.CoffeeShop == null)
				return false;
			return (await this.favoriteService.GetFavorites()).Any (f => f == this.CoffeeShop.Id);
		}
	}
}


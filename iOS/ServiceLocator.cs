using System;
using FormationVDO;
using System.IO;
using FormationVDO.Infrastructure;
using System.Net.Http;
using Formation.Forms.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(ServiceLocator))]

namespace Formation.Forms.iOS
{
	public class ServiceLocator : IServiceLocator
	{
		#region IServiceLocator implementation

		public CoffeeListViewModel CoffeeListViewModel { get; set; }

		public CoffeeViewModel CoffeeViewModel { get; set; }
		public INavigationService NavigationService { get; set; }

		#endregion

		public ServiceLocator ()
		{
			var path = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);

			var dbConnectionProvider = new DbConnectionProvider (Path.Combine (path, "user-db"));
			var httpProvider = new HttpClientProvider (() => new CFNetworkHandler ());

			dbConnectionProvider.InitializeDb ();

			var favoriteService = new FavoriteService (dbConnectionProvider);
			var coffeeService = new CoffeeService (httpProvider);
			this.NavigationService = new Navigation ();

			this.CoffeeListViewModel = new CoffeeListViewModel (coffeeService, favoriteService);
			this.CoffeeViewModel = new CoffeeViewModel (favoriteService, this.NavigationService);

		}
	}
}


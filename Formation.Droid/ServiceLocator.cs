using System;
using FormationVDO.Infrastructure;
using FormationVDO;
using System.IO;

namespace Formation.Droid
{
	public class ServiceLocator : IServiceLocator
	{
		#region IServiceLocator implementation

		public FormationVDO.CoffeeListViewModel CoffeeListViewModel { get; set; }
		public FormationVDO.CoffeeViewModel CoffeeViewModel { get; set; }
		public FormationVDO.INavigationService NavigationService { get; set; }

		#endregion

		public ServiceLocator ()
		{
			var path = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);

			var dbConnectionProvider = new DbConnectionProvider (Path.Combine (path, "user-db"));
			var httpProvider = new HttpClientProvider (() => new ModernHttpClient.NativeMessageHandler ());

			dbConnectionProvider.InitializeDb ();

			var favoriteService = new FavoriteService (dbConnectionProvider);
			var coffeeService = new CoffeeService (httpProvider);
			this.NavigationService = new Navigation ();

			this.CoffeeListViewModel = new CoffeeListViewModel (coffeeService, favoriteService);
			this.CoffeeViewModel = new CoffeeViewModel (favoriteService, this.NavigationService);
		}
	}
}


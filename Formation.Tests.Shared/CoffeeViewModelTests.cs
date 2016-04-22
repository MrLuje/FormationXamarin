using System;
using NUnit.Framework;
using FormationVDO;
using RichardSzalay.MockHttp;
using System.Linq;
using System.Threading.Tasks;

namespace Formation.Tests.Shared
{
	[TestFixture ()]
	public class CoffeeViewModelTests
	{
		CoffeeViewModel _viewModel;
		TestDbConnectionProvider dbProvider;
		FavoriteService _favoriteSvc;

		[TestFixtureSetUp]
		public void Setup()
		{
			dbProvider = new TestDbConnectionProvider ("pwetDb");

			_favoriteSvc = new FavoriteService (dbProvider);
			_viewModel = new CoffeeViewModel (_favoriteSvc, null);
		}

		[TestFixtureTearDown]
		public void CleanUp(){
			dbProvider.GetConnection ().DropTableAsync<FavoriteRow> ().Wait();
		}

		[Test]
		[Timeout(1000)]
		public async Task favoriteService_should_add_favorite_to_db()
		{
			await dbProvider.InitializeDb ();
			var p = new Navigation() ;
			p.CurrentParameter = new CoffeeShop{ Id = "abcId" };
			_viewModel = new CoffeeViewModel (_favoriteSvc, p);
			 _viewModel.Initialize ();

			await _viewModel.AddToFavorite ();

			Assert.IsTrue ((await _favoriteSvc.GetFavorites ()).Count (f => f == "abcId") == 1);
		}

		[Test]
		[Timeout(1000)]
		public async Task favoriteService_should_remove_favorite_to_db()
		{
			await dbProvider.InitializeDb ();
			var p = new Navigation ();
				p.CurrentParameter = new CoffeeShop{ Id = "abcId" };
			_viewModel = new CoffeeViewModel (_favoriteSvc, p);
			_viewModel.Initialize ();

			await _favoriteSvc.AddToFavorite ("abcId");
			Assert.IsTrue ((await _favoriteSvc.GetFavorites ()).Count (f => f == "abcId") == 1, "Favorite is not in the db");

			await _viewModel.RemoveFromFavorite ();
			Assert.IsTrue ((await _favoriteSvc.GetFavorites ()).Count (f => f == "abcId") == 0, "Favorite is still is db");
		}
	}
}


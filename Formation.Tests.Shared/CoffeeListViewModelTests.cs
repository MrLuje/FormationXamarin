using NUnit.Framework;
using System;
using FormationVDO;
using System.Linq;
using Formation.Tests.Shared;
using System.Threading.Tasks;
using System.Net.Http;
using RichardSzalay.MockHttp;
using System.Collections.Generic;

namespace Formation.Tests
{
	[TestFixture ()]
	public class CoffeeListViewModelTests
	{
		CoffeeListViewModel _viewModel;
		TestDbConnectionProvider dbProvider;
		HttpClientProvider httpProvider;
		MockHttpMessageHandler handler;
		const string _samplie_json =@"
		{
		    ""format"": ""json"",
		    ""nhits"": 1,
		    ""records"": [
		        {
		            ""datasetid"": ""liste-des-cafes-a-un-euro"",
		            ""fields"": {
		                ""adresse"": ""344 rue Vaugirard"",
		                ""arrondissement"": 75015,
		                ""date"": ""2014-02-01"",
		                ""geoloc"": [
		                    48.839471,
		                    2.30286
		                ],
		                ""nom_du_cafe"": ""Coffee Chope"",
		                ""prix_comptoir"": 1,
		                ""prix_salle"": ""-"",
		                ""prix_terasse"": ""-""
		            },
		            ""geometry"": {
		                ""coordinates"": [
		                    2.30286,
		                    48.839471
		                ],
		                ""type"": ""Point""
		            },
		            ""record_timestamp"": ""2016-02-14T23:00:04+00:00"",
		            ""recordid"": ""4588e58f447fb4dd5df12eafbaf7d9314decd475""
		        }
		    ],
		    ""rows"": 10,
		    ""timezone"": ""UTC""
		}";

		[TestFixtureSetUp]
		public void Setup()
		{
			dbProvider = new TestDbConnectionProvider ();

			handler = new MockHttpMessageHandler ();
			httpProvider = new HttpClientProvider (() => handler);

			handler
				.When (CoffeeService.apiUrl.ToString())
				.Respond (System.Net.HttpStatusCode.OK, "application/json", _samplie_json);	
		}

		[TestFixtureTearDown]
		public void Cleanup(){
			dbProvider.GetConnection ().DropTableAsync<FavoriteRow> ().Wait();
		}

		[Test ()]
		[Timeout(1000)]
		public async Task Should_load_favorite_coffees_at_init ()
		{
			_viewModel = new CoffeeListViewModel (
				new CoffeeServiceMock(new List<CoffeeShop>{new CoffeeShop{Id="test"}}), 
				new FavoriteService(dbProvider)
			);

			await dbProvider.InitializeDb ();
			await dbProvider.GetConnection ().AddToDb (new FavoriteRow { FavoriteId = "test" });

			await _viewModel.Initialize ();

			Assert.IsTrue (_viewModel.FavoriteCoffees.Count (f => f.Id == "test") == 1);
		}

		[Test]
		[Timeout(1000)]
		public async Task Should_load_all_coffee_on_init()
		{
			_viewModel = new CoffeeListViewModel (
				new CoffeeService(httpProvider), 
				new FavoriteServiceMock()
			);

			await dbProvider.InitializeDb ();
			await _viewModel.Initialize ();

			Assert.IsTrue (_viewModel.AllCoffees.Any ());
			foreach (var coffee in _viewModel.AllCoffees) {
				Assert.IsFalse(string.IsNullOrEmpty(coffee.Name));
				Assert.IsFalse(string.IsNullOrEmpty(coffee.Id));
			}
		}
	}

	public class CoffeeServiceMock : ICoffeeService
	{
		List<CoffeeShop> coffees;

		public CoffeeServiceMock (List<CoffeeShop> coffees)
		{
			this.coffees = coffees;
			
		}

		#region ICoffeeService implementation
		public async Task<System.Collections.Generic.IEnumerable<CoffeeShop>> GetAll ()
		{
			return await Task.FromResult(coffees);
		}
		#endregion
	}

	public class FavoriteServiceMock : IFavoriteService{
		#region IFavoriteService implementation
		public Task AddToFavorite (string coffeeId)
		{
			return Task.FromResult (0);
		}

		public Task RemoveFromFavorite (string coffeeId)
		{
			return Task.FromResult (0);
		}

		public async Task<IList<string>> GetFavorites ()
		{
			return await Task.FromResult(new List<string> ());
		}
		#endregion
	}	
}


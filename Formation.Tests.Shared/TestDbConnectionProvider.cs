using System;
using FormationVDO;
using System.Threading.Tasks;

namespace Formation.Tests.Shared
{
	public class TestDbConnectionProvider : IDbConnectionProvider
	{
		SQLite.SQLiteAsyncConnection _connection;

		public TestDbConnectionProvider (string dbName = "my-db")
		{
			_connection = new SQLite.SQLiteAsyncConnection (dbName);
		}

		public async Task InitializeDb ()
		{
			await _connection.CreateTableAsync<FavoriteRow> ();
		}

		#region IDbConnectionProvider implementation

		public SQLite.SQLiteAsyncConnection GetConnection ()
		{
			return _connection;
		}

		#endregion
	}
}


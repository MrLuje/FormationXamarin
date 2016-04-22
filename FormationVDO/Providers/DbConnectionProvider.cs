using System;
using System.Threading.Tasks;

namespace FormationVDO
{
	public class DbConnectionProvider: IDbConnectionProvider
	{
		SQLite.SQLiteAsyncConnection _connection;

		public DbConnectionProvider (string dbPath)
		{
			_connection = new SQLite.SQLiteAsyncConnection (dbPath);
		}

		public Task InitializeDb ()
		{
			return _connection.CreateTableAsync<FavoriteRow> ();
		}

		#region IDbConnectionProvider implementation

		public SQLite.SQLiteAsyncConnection GetConnection ()
		{
			return _connection;
		}

		#endregion
	}
}


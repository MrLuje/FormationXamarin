using System;
using FormationVDO;
using System.Threading.Tasks;

namespace Formation.Tests.Shared
{
	public static class TestHelper
	{
		public async static Task<int> AddToDb(this SQLite.SQLiteAsyncConnection connection, FavoriteRow row){
			return await connection.InsertAsync (row);
		}
	}
}


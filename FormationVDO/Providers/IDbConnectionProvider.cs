using System;
using SQLite;

namespace FormationVDO
{
	public interface IDbConnectionProvider
	{
		SQLiteAsyncConnection GetConnection();
	}
}


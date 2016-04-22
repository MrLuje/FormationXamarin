using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace FormationVDO
{
	public class FavoriteService  : IFavoriteService
	{
		readonly IDbConnectionProvider provider;

		public FavoriteService (IDbConnectionProvider provider)
		{
			this.provider = provider;
		}

		#region IFavoriteService implementation

		public async Task AddToFavorite (string coffeeId)
		{
			await this.provider.GetConnection ().InsertAsync (new FavoriteRow { FavoriteId = coffeeId });
		}

		public async Task RemoveFromFavorite (string coffeeId)
		{
			await this.provider.GetConnection().DeleteAsync(new FavoriteRow {FavoriteId = coffeeId});
		}

		public async Task<IList<string>> GetFavorites ()
		{
			var result = await provider.GetConnection ().QueryAsync<FavoriteRow>("SELECT * FROM FavoriteRow");
			return result.Select(c => c.FavoriteId).ToList();
		}

		#endregion
	}
}


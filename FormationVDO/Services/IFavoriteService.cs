using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormationVDO
{
	public interface IFavoriteService
	{
		Task AddToFavorite(string coffeeId);
		Task RemoveFromFavorite(string coffeeId);
		Task<IList<string>> GetFavorites();
	}
}


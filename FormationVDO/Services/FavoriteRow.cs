using System;
using SQLite;

namespace FormationVDO
{
	[Table("FavoriteRow")]
	public class FavoriteRow
	{
		[PrimaryKey]
		public string FavoriteId {
			get;
			set;
		}
	}
}


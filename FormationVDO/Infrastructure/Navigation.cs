using System;

namespace FormationVDO
{
	public class Navigation : INavigationService
	{
		#region INavigationService implementation

		public CoffeeShop CurrentParameter { get; set;}

		#endregion

		public Navigation ()
		{
		}
	}
}


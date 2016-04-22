using System;
using System.IO;

namespace FormationVDO.Infrastructure
{
	public interface IServiceLocator {
		 CoffeeListViewModel CoffeeListViewModel { get; set; }
		 CoffeeViewModel CoffeeViewModel { get; set; }
		 INavigationService NavigationService { get; set; }
	}

}


using System;

namespace FormationVDO
{
	public interface IMapService
	{
		IMapService Configure();
		void ShowCoffee(CoffeeShop coffee);
		void SetMap(object map);
	}
}


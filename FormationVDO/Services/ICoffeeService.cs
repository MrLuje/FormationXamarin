using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FormationVDO
{
	public interface ICoffeeService
	{
		Task<IEnumerable<CoffeeShop>> GetAll();
	}
}


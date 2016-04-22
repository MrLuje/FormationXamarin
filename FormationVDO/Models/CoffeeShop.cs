using System;

namespace FormationVDO
{
	public class CoffeeShop
	{
		public string Name {
			get;
			set;
		}

		public string Address {
			get;
			set;
		}
		public string Id {
			get;
			set;
		}

		public Coordinates Coordinates {
			get;
			set;
		}

		public CoffeeShop ()
		{
			
		}
	}

	public class Coordinates
	{
		public double Latitude {
			get;
			set;
		}

		public double Longitude {
			get;
			set;
		}
	}
}


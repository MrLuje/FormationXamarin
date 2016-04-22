using System;
using FormationVDO;
using Formation.Forms.Droid;
using Xamarin.Forms.Maps;

[assembly: Xamarin.Forms.Dependency(typeof(MapService))]
	
namespace Formation.Forms.Droid
{
	public class MapService : IMapService
	{
		Map map;

		public MapService ()
		{
		}

		#region IMapService implementation

		public IMapService Configure ()
		{
			return this;
		}

		public void SetMap (object map)
		{
			this.map = (Map)map;
		}

		public void ShowCoffee (CoffeeShop coffee)
		{
			var position = new Position(
				coffee.Coordinates.Latitude,
				coffee.Coordinates.Longitude
			); 

			var pin = new Pin {
				Type = PinType.Place,
				Position = position,
				Label = coffee.Name,
				Address = coffee.Address
			};

			this.map.Pins.Add (pin);
			this.map.MoveToRegion(
				MapSpan.FromCenterAndRadius(
					position, Distance.FromMiles(.1)));
		}

		#endregion
	}
}


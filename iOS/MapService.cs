using System;
using FormationVDO;
using Xamarin.Forms.Maps;
using Formation.Forms.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(MapService))]
	
namespace Formation.Forms.iOS
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
			); // Latitude, Longitude

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


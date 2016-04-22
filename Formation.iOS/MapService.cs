using System;
using FormationVDO;
using MapKit;

namespace Formation.iOS
{
	public class MapService : IMapService
	{
		MKMapView map;

		public MapService (MKMapView map)
		{
			this.map = map;
		}

		#region IMapService implementation

		public void SetMap (object map)
		{
			throw new NotImplementedException ();
		}

		public IMapService Configure ()
		{
			return this;
		}

		public void ShowCoffee (CoffeeShop coffee)
		{
			var coord = new CoreLocation.CLLocationCoordinate2D (
				coffee.Coordinates.Latitude,
				coffee.Coordinates.Longitude
			);
			var annotation = new MKPointAnnotation {
				Title = coffee.Name,
				Coordinate = coord
			};
			this.map.AddAnnotation (annotation);
			this.map.ShowAnnotations (new IMKAnnotation[] {annotation}, true);
			this.map.SelectAnnotation (annotation, true);

			var span = new MKCoordinateSpan(.01f, .01f);
			map.Region = new MKCoordinateRegion(coord, span);
		}

		#endregion
	}
}


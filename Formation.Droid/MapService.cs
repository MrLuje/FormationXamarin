using System;
using FormationVDO;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Com.Google.Maps.Android.Clustering;
using Com.Google.Maps.Android.UI;
using Android.Content;

namespace Formation.Droid
{
	public class MapService : IMapService
	{
		GoogleMap map;

		Context context;

		public MapService (GoogleMap map, Context context)
		{
			this.context = context;
			this.map = map;
		}

		public void SetMap (object map)
		{
			throw new NotImplementedException ();
		}

		#region IMapService implementation

		public IMapService Configure ()
		{
			map.MapType = GoogleMap.MapTypeNormal;

			return this;
		}

		public void ShowCoffee (CoffeeShop coffee)
		{
			var coord = new LatLng (coffee.Coordinates.Latitude, coffee.Coordinates.Longitude);
			var markerOpt1 = new MarkerOptions();
			markerOpt1.SetPosition(coord);
			markerOpt1.SetTitle(coffee.Name);


			var iconFactory = new IconGenerator(this.context);
			addIcon(iconFactory, coffee.Name, coord);

			var maker = map.AddMarker(markerOpt1);
			maker.ShowInfoWindow ();

			var builder = CameraPosition.InvokeBuilder();
			builder.Target(coord);
			builder.Zoom(18);
			builder.Bearing(155);
			builder.Tilt(65);
			var cameraPosition = builder.Build();
			var cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);

			map.MoveCamera (cameraUpdate);

		}

		 void addIcon(IconGenerator iconFactory, string text, LatLng position) {
			return;

			var markerOptions = new MarkerOptions ();
			markerOptions.SetIcon(BitmapDescriptorFactory.FromBitmap (iconFactory.MakeIcon (text)));
			markerOptions.SetPosition(position);
			markerOptions.Anchor(iconFactory.AnchorU, iconFactory.AnchorV);

			this.map.AddMarker(markerOptions);
		}

		#endregion
	}

	public class TestAdapter : Android.Gms.Maps.GoogleMap.IInfoWindowAdapter{
		#region IInfoWindowAdapter implementation

		public Android.Views.View GetInfoContents (Marker marker)
		{
			throw new NotImplementedException ();
		}

		public Android.Views.View GetInfoWindow (Marker marker)
		{
			throw new NotImplementedException ();
		}

		#endregion

		#region IDisposable implementation

		public void Dispose ()
		{
			throw new NotImplementedException ();
		}

		#endregion

		#region IJavaObject implementation

		public IntPtr Handle {
			get {
				throw new NotImplementedException ();
			}
		}

		#endregion


	}
}


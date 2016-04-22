using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace FormationVDO
{
	public static class CoffeeShopMapper
	{
		public static IEnumerable<CoffeeShop> MapToCoffeeShop (this string json)
		{
			var data = JsonConvert.DeserializeObject (json) as JObject;

			foreach (var record in data["records"]) {


				CoffeeShop coffe = null;
				try{
					var fields = (record as JObject) ["fields"];
					var localisation = (record as JObject) ["geometry"] as JObject;
					var coordinates = localisation ["coordinates"] as JArray;
				coffe= new CoffeeShop {
					Name = fields ["nom_du_cafe"].Value<string> (),
					Address = fields ["adresse"].Value<string> (),
					Id = record ["recordid"].Value<string> (),
					Coordinates = new Coordinates {
						Latitude =	coordinates.ElementAt (1).Value<double> (),
						Longitude = coordinates.ElementAt (0).Value<double> ()
					}
				};
				}
				catch{
					coffe = new CoffeeShop{ Name = "crash" };
				}

				yield return coffe;
			}
		}
	}
}


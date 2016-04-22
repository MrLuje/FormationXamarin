using System;
using System.Collections.Generic;

namespace FormationVDO
{
	public class CoffeeService : ICoffeeService
	{
		readonly IHttpClientProvider provider;
		public static string apiUrl = "http://opendata.paris.fr/api/records/1.0/search/?dataset=liste-des-cafes-a-un-euro&rows=100";

		public CoffeeService (IHttpClientProvider provider)
		{
			this.provider = provider;
		}

		#region ICoffeeService implementation

		public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<CoffeeShop>> GetAll ()
		{
			using (var client = this.provider.GetClient ()) {
				var json = await client.GetStringAsync (apiUrl);
				return json.MapToCoffeeShop ();
			}

			return new List<CoffeeShop> ();
		}

		#endregion
	}
}


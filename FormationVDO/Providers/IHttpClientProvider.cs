using System;
using System.Net.Http;

namespace FormationVDO
{
	public interface IHttpClientProvider
	{
		HttpClient GetClient();
	}
}


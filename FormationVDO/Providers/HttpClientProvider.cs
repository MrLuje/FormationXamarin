using System;
using System.Net.Http;

namespace FormationVDO
{
	public class HttpClientProvider : IHttpClientProvider
	{
		Func<HttpMessageHandler> handler;

		public HttpClientProvider (Func<HttpMessageHandler> handler)
		{
			this.handler = handler;
		}

		#region IHttpClientProvider implementation

		public HttpClient GetClient ()
		{
			return new HttpClient(handler());
		}

		#endregion
	}
}


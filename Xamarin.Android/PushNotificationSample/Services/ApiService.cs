using System;
using Refit;
using System.Net.Http;
using ModernHttpClient;
using System.Threading.Tasks;
using PushNotificationSample.Models.Responses;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PushNotificationSample.Services
{
	public class ApiService: IApiService
	{
		public ApiService(string apiBaseAddress)
		{
			Func<HttpMessageHandler, IParseApi> createClient = messageHandler =>
			{
				var client = new HttpClient(messageHandler)
				{
					BaseAddress = new Uri(apiBaseAddress)
				};
				return RestService.For<IParseApi>(client);
			};

			_httpClient = new Lazy<IParseApi>(() => createClient(new NativeMessageHandler()));

		}

		private readonly Lazy<IParseApi> _httpClient;


		public async Task<ParseResult> RegisterDeviceAsync(string deviceType, string deviceToken)
		{

			var parameters = new Dictionary<string,object>();
			parameters.Add("deviceType", deviceType);
			parameters.Add("pushType", "gcm");
			parameters.Add("GCMSenderId", Constants.GcmSenderId);
			parameters.Add("deviceToken",deviceToken);
			parameters.Add("channels",new List<string>(){""});


			Console.WriteLine(JsonConvert.SerializeObject(parameters));

			var r = await _httpClient.Value.RegisterDevice(parameters);
			return r;
		}


	}
}


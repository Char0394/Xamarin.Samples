using System;
using PushNotificationSample.Models.Responses;
using System.Threading.Tasks;

namespace PushNotificationSample.Services
{
	public interface IApiService
	{
		Task<ParseResult> RegisterDeviceAsync(string deviceType, string deviceToken);
	}
}


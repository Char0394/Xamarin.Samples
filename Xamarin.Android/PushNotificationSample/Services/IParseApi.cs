using System;
using System.Threading.Tasks;
using Refit;
using System.Collections.Generic;
using PushNotificationSample.Models.Responses;

namespace PushNotificationSample.Services
{
	[Headers("X-Parse-Application-Id: " + Constants.ParseApplicationId, "X-Parse-REST-API-Key: " + Constants.ParseRestApiKey, "Content-Type: application/json")]
	public interface IParseApi
	{
		[Post("/1/installations")]
		Task<ParseResult> RegisterDevice([Body] Dictionary<string,object> data);
	}
}


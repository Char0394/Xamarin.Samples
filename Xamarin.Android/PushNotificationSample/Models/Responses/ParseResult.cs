using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PushNotificationSample.Models.Responses
{
	/// <summary>
	/// Base class for result from Parse API request.
	/// </summary>
	public class ParseResult
	{

		[JsonProperty("code")]
		public int Code { get; set; }
		[JsonProperty("error")]
		public string Error { get; set; }
		[JsonProperty("objectId")]
		public string ObjectId{ get; set; }
		[JsonProperty("createdAt")]
		public DateTime CreatedAt { get; set; }



	}

	/// <summary>
	/// Base class for result from Parse API request.
	/// </summary>
	public class ParseResult<T> : ParseResult
	{

		public T Result { get; set; }

	}
		

}


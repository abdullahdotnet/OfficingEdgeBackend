using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OfficeModels.Responses
{
	public class Response
	{
		[JsonIgnore]
		public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
		[JsonIgnore]
		public List<string> ErrorMessages { get; set; } 

		public string Message { get; set; } = string.Empty;
	}
}

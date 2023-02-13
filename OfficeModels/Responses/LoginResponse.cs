using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OfficeModels.Responses
{
	public class LoginResponse : Response
	{
		public string Token { get; set; }
		public DateTime Expiration
		{
			get; set;
		}
	}
}

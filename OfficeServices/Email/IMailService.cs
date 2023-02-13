using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeServices.Email
{
	public interface IMailService
	{
		Task<Response> SendMailAsync(string email, string subject, string body);
	}
}

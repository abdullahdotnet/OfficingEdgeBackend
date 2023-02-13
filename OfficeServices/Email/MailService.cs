
using Microsoft.Extensions.Configuration;
using OfficeServices.Email;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectCoRepositry.Implementations.Email
{
    public class MailService : IMailService
    {
        public readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Response> SendMailAsync(string email, string subject, string body)
        {
            try
            {
				var apikey = "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";
				var client = new SendGridClient(apikey);
				var from = new EmailAddress("abdullahdotnet20@gmail.com");
				var to = new EmailAddress(email);
                var msg = MailHelper.CreateSingleEmail(from, to, subject, body, body);
				var response = await client.SendEmailAsync(msg);
				return response;
			}
            catch
            {
                throw new Exception();
            }
			
            
        }

		
	}
}

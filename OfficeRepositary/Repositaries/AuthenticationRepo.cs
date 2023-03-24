using OfficeModels.Requests;
using OfficeModels.Responses;
using OfficingEdge.Interfaces;
using System.Net;
using System.Security.Claims;
using System.Linq;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using OfficeRepositary.Repositaries;
using Office.DataLayer.Data;

namespace OfficingEdge.Repositaries
{
	public class AuthenticationRepo : IAuthentication
	{
		private readonly db_a9696f_officeContext _db;
		public AuthenticationRepo(db_a9696f_officeContext db)
		{
			_db = db;
		}

		public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
		{
			EncryptionDecryptionService encdyc = new EncryptionDecryptionService();
			var user = await _db.Employees.FirstOrDefaultAsync(x => x.EmpEmail == loginRequest.EmailAddress);
			if (loginRequest.EmailAddress != user.EmpEmail)
				return new LoginResponse { StatusCode = HttpStatusCode.Unauthorized, ErrorMessages = new() { "Invalid Email" } }; // Error Response
			var decrypted = encdyc.PasswordDecryption(user.EmpPassword);
			return new LoginResponse { StatusCode = HttpStatusCode.Unauthorized, ErrorMessages = new() { "Invalid Password" } }; // Error Response

			return null;



		}

	}
}

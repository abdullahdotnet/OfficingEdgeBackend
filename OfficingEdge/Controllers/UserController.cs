using CollectCoModels.Response;
using CollectCoRepositry.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Office.DataLayer.Identity;
using OfficeModels.Request;
using OfficeModels.Requests;
using OfficeModels.Responses;
using OfficeModels.ViewModels;
using OfficeRepositary.Interfaces;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net;

namespace OfficingEdge.Controllers
{
	[ApiController]
	[Route("/")]
	public class UserController : BaseController
	{
		private readonly IUserRepo _user;
		public UserController(IUserRepo user)
		{
			_user = user;
		}
		[HttpPost("PunchIn")]
		public async Task<ActionResult<ResponseDto>> punchIn([FromBody] PunchRequest request)
		{
	
			if (!ModelState.IsValid)
				return GetResponse(new Response { StatusCode = HttpStatusCode.BadRequest, ErrorMessages = new() { "Request Not Valid" } });

			var response = await _user.punchIn(request);

			return GetResponse(response);
			
		}
		[HttpGet("GetUser")]
		[ProducesResponseType(typeof(UserVM), StatusCodes.Status200OK)]
		public async Task<ActionResult<ResponseDto>> GetUser(string id)
		{
			if (!ModelState.IsValid)
				return GetResponse(new Response { StatusCode = HttpStatusCode.BadRequest, ErrorMessages = new() { "Request Not Valid" } });

			var response = await _user.GetUser(id);

			return GetResponse(response);

		}
		[HttpGet("GetAllUser")]
		[ProducesResponseType(typeof(UserList), StatusCodes.Status200OK)]
		public async Task<ActionResult<ResponseDto>> GetAllUser()
		{
			if (!ModelState.IsValid)
				return GetResponse(new Response { StatusCode = HttpStatusCode.BadRequest, ErrorMessages = new() { "Request Not Valid" } });

			var response = await _user.GetAllUser();

			return GetResponse(response);

		}
		[HttpDelete("DeleteUser")]
		public async Task<ActionResult<ResponseDto>> DeleteUser(string id)
		{
			if (!ModelState.IsValid)
				return GetResponse(new Response { StatusCode = HttpStatusCode.BadRequest, ErrorMessages = new() { "Request Not Valid" } });

			var response = await _user.DeleteUser(id);

			return GetResponse(response);
		}
	}
}

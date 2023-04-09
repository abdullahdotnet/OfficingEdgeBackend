using CollectCoModels.Response;
using CollectCoRepositry.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeModels.Request;
using OfficeModels.Requests;
using OfficeModels.Responses;
using OfficeRepositary.Interfaces;
using System.Net;

namespace OfficingEdge.Controllers
{
	[ApiController]
	[Route("/")]
	public class AuthController : BaseController
	{
		private readonly IAuthentication _authentication;
		public AuthController(IAuthentication authentication)
		{
			_authentication = authentication;
		}

		[HttpPost("Login")]

		//[Authorize(Roles = "User")]
		[AllowAnonymous]
		public async Task<ActionResult<ResponseDto>> Login([FromBody] LoginRequest loginRequest)
		{
			if (!ModelState.IsValid)
				return GetResponse(new Response { StatusCode = HttpStatusCode.BadRequest, ErrorMessages = new() { "Request Not Valid" } });

			var response = await _authentication.LoginAsync(loginRequest);
			return GetResponse(response);
		}
		[HttpPost("Register")]
		//[Authorize(Roles = "Admin")]
		[AllowAnonymous]
		public async Task<ActionResult<ResponseDto>> Register([FromBody] RegisterUserRequest registerUserRequest)
		{
			if (!ModelState.IsValid)
				return GetResponse(new Response { StatusCode = HttpStatusCode.BadRequest, ErrorMessages = new() { "Request Not Valid" } });

			var response = await _authentication.RegisterUserAsync(registerUserRequest);

			return GetResponse(response);
		}
	}
}

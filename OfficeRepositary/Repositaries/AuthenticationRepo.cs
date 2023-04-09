using OfficeModels.Requests;
using OfficeModels.Responses;
using OfficeRepositary.Interfaces;
using System.Net;
using System.Security.Claims;
using System.Linq;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using OfficeRepositary.Repositaries;
using Microsoft.AspNetCore.Identity;
using Office.DataLayer.Identity;
using System.IdentityModel.Tokens.Jwt;
using OfficeServices.Log;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using OfficeRepositary.Mapper.Interface;
using OfficeEnums;
using AutoMapper;
using OfficeModels.DTOs;
using OfficeModels.Request;
using IdentityModel;
using Task = System.Threading.Tasks.Task;
using Office.DataLayer.data;

namespace OfficeRepositary.Repositaries
{
	public class AuthenticationRepo : IAuthentication
	{
		private readonly db_a9696f_officeContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signinManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IAuthenticationMapper _authenticationMapper;
		private readonly IConfiguration _configuration;
		private readonly ILogService _log;
		public readonly IMapper _mapper;
		public AuthenticationRepo(db_a9696f_officeContext db,
			ILogService log, IConfiguration configuration,
			IAuthenticationMapper authenticationMapper, IMapper mapper,
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			RoleManager<IdentityRole> roleManager)
		{
			_db = db;
			_log = log;
			_configuration = configuration;
			_authenticationMapper = authenticationMapper;
			_mapper = mapper;
			_signinManager = signInManager;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
		{
			var user = await _userManager.FindByNameAsync(loginRequest.UserName);
			var result = await ValidateUser(user, loginRequest.Password);
			if (result == false)
				return new LoginResponse { StatusCode = HttpStatusCode.Unauthorized, ErrorMessages = new() { "Invalid Username or Password" } }; // Error Response
			
			var userRoles = await _userManager.GetRolesAsync(user);

			var authClaims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.Id),
					new Claim(ClaimTypes.NameIdentifier, user.Id),
					new Claim(ClaimTypes.Email, user.Email),
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				};

			foreach (var userRole in userRoles)
			{
				authClaims.Add(new Claim(ClaimTypes.Role, userRole));
			}

			var token = GetToken(authClaims);
			_log.LogInformation($"User '{user.Id}' logged In");

			return new LoginResponse
			{
				Token = new JwtSecurityTokenHandler().WriteToken(token),
				Expiration = token.ValidTo
			};
		}
		public async Task<RegisterUserResponse> RegisterUserAsync(RegisterUserRequest registerUserRequest)
		{
			var userExistswithUserName = await _userManager.FindByNameAsync(registerUserRequest.Username);
			var userExistswithEmail = await _userManager.FindByEmailAsync(registerUserRequest.Email);
			if (userExistswithUserName != null || userExistswithEmail != null)
				return new RegisterUserResponse { StatusCode = HttpStatusCode.Conflict, ErrorMessages = new() { "Username or Email already Exist" } };
			var user = _authenticationMapper.RegisterUserRequestMapToApplicationUser(registerUserRequest);

			var result = await _userManager.CreateAsync(user, registerUserRequest.Password);
			if (!result.Succeeded)
				return new RegisterUserResponse { StatusCode = HttpStatusCode.BadRequest, ErrorMessages = new() { "Request not valid" } };

			if (!await _roleManager.RoleExistsAsync(Enum.GetName(typeof(UserRole), registerUserRequest.UserRole)))
				await _roleManager.CreateAsync(new IdentityRole(Enum.GetName(typeof(UserRole), registerUserRequest.UserRole)));

			await _userManager.AddToRoleAsync(user, Enum.GetName(typeof(UserRole), registerUserRequest.UserRole));
			var registerdUser = await _userManager.FindByNameAsync(registerUserRequest.Username);

			await AddClaims(user, registerdUser);
			var userDto = _mapper.Map<UserDto>(registerdUser);
			_log.LogInformation($"User '{user.Id}' new register account");

			return new RegisterUserResponse { Message = "User Created", User = userDto };
		}
		private JwtSecurityToken GetToken(List<Claim> authClaims)
		{
			var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Configuration:JWTSecret"]));

			var token = new JwtSecurityToken(
				issuer: _configuration["Configuration:JWTValidIssuer"],
				expires: DateTime.Now.AddHours(6),
				claims: authClaims,
				signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
				);

			return token;
		}
		private async Task AddClaims(ApplicationUser user, ApplicationUser registerdUser)
		{
			await _userManager.AddClaimsAsync(user, new Claim[]
			{
				new Claim(JwtClaimTypes.Name, registerdUser.UserName),
				new Claim(JwtClaimTypes.Email, registerdUser.Email),
				new Claim(JwtClaimTypes.Id, registerdUser.Id)
			});
		}
		private async Task<bool> ValidateUser(ApplicationUser user, string Password)
		{
			return await _signinManager.UserManager.CheckPasswordAsync(user, Password);
		}
	}
}

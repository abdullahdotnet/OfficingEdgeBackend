using OfficeModels.Request;
using OfficeModels.Requests;
using OfficeModels.Responses;

namespace OfficeRepositary.Interfaces
{
	public interface IAuthentication
	{
		Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
		Task<RegisterUserResponse> RegisterUserAsync(RegisterUserRequest registerUserRequest);
	}
}

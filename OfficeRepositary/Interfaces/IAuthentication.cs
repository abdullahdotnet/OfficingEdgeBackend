using OfficeModels.Requests;
using OfficeModels.Responses;

namespace OfficingEdge.Interfaces
{
	public interface IAuthentication
	{
		Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
	}
}

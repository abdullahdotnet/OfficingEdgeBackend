using Office.DataLayer.Identity;
using OfficeModels.Request;
using OfficeRepositary.Mapper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeRepositary.Mapper.Implementation
{
    public class AuthenticationMapper : IAuthenticationMapper
    {
        public ApplicationUser RegisterUserRequestMapToApplicationUser(RegisterUserRequest registerUserRequest)
        {
            return new ApplicationUser()
            {
                firstName = registerUserRequest.FirstName,
                lastName = registerUserRequest.LastName,
                PhoneNumber = registerUserRequest.PhoneNumber,
                Email = registerUserRequest.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUserRequest.Username,
				companyEmail = registerUserRequest.companyEmail,
				shiftStart = registerUserRequest.shiftStart,
				shiftEnd = registerUserRequest.shiftEnd,
				shiftDuration = registerUserRequest.shiftDuration,
				EmpDepId = registerUserRequest.empDepId,
				EmpTypeId = registerUserRequest.empTypeId
            };
        }
		#region
		//public ApplicationUser UpdateUserRequestMapToApplicationUser(UpdateUserRequest updateUserRequest, ApplicationUser registerdUser)
		//{
		//    registerdUser.FirstName = updateUserRequest.FirstName;
		//    registerdUser.LastName = updateUserRequest.LastName;
		//    registerdUser.Address = updateUserRequest.Address;
		//    registerdUser.PhoneNumber = updateUserRequest.PhoneNumber;
		//    registerdUser.MobileCountryCode = updateUserRequest.MobileCountryCode;
		//    registerdUser.Email = updateUserRequest.Email;
		//    registerdUser.UserName = updateUserRequest.Username;
		//    return registerdUser;
		//}
		#endregion
	}
}

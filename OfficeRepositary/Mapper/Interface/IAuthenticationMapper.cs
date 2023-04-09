using OfficeModels.Request;
using Office.DataLayer.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeRepositary.Mapper.Interface
{
    public interface IAuthenticationMapper
    {
        ApplicationUser RegisterUserRequestMapToApplicationUser(RegisterUserRequest registerUserRequest);
        //ApplicationUser UpdateUserRequestMapToApplicationUser(UpdateUserRequest updateUserRequest,ApplicationUser registerdUser);
    }
}

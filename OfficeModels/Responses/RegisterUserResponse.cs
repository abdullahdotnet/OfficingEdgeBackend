using OfficeModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeModels.Responses
{
    public class RegisterUserResponse : Response
    {
        public UserDto User { get; set; }
    }
}

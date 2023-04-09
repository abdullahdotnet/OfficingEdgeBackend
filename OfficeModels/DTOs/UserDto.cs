using OfficeEnums;
using Org.BouncyCastle.Utilities.IO.Pem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeModels.DTOs
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string companyEmail { get; set; }
        public string MobileCountryCode { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateTimeUTCCreated { get; set; }
        public bool IsBlocked { get; set; }
        public bool EmailConfirmed { get; set; }
        public UserRole UserRole { get; set; }
		public DateTime? shiftStart { get; set; }
		public DateTime? shiftEnd { get; set; }
        public int? shiftDuration { get; set; }
    }
}

using OfficeEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OfficeModels.Request
{
    public class RegisterUserRequest
    {
		[StringLength(50, MinimumLength = 2), Required(ErrorMessage = "FirstName is required")]
		public string FirstName { get; set; }
		[StringLength(50, MinimumLength = 2), Required(ErrorMessage = "LastName is required")]
		public string LastName { get; set; }
		[StringLength(50, MinimumLength = 2), Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }
        [EmailAddress]
        [StringLength(50, MinimumLength = 2), Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
		[EmailAddress]
		[StringLength(50, MinimumLength = 2), Required(ErrorMessage = "Company Email is required")]
		public string companyEmail { get; set; }
		[StringLength(50, MinimumLength = 2), Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [StringLength(50, MinimumLength = 2), Required(ErrorMessage = "Password is required")]
        public string? PhoneNumber { get; set; }
        [Range(0,500)]
        public UserRole UserRole { get; set; }
		[Range(0, 500)]
		public int empDepId { get; set; }
		[Range(0, 500)]
		public int empTypeId { get; set; }
		public DateTime shiftStart { get; set; }
		public DateTime shiftEnd { get; set; }
		public int shiftDuration { get; set; }

       
    }
}

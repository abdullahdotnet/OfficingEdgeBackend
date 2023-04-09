using Microsoft.AspNetCore.Identity;
//using Office.DataLayer.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Office.DataLayer.Identity
{
	public class ApplicationUser : IdentityUser
	{
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string companyEmail { get; set; }
		public int? EmpDepId { get; set; }
		public int? EmpTypeId { get; set; }
		public DateTime? shiftStart { get; set; }
		public DateTime? shiftEnd { get; set; }
		public int? shiftDuration { get; set; }

	}
}

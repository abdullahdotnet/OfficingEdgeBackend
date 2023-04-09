using Office.DataLayer.Identity;
using OfficeModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeModels.ViewModels
{
	public class UserList : Response
	{
		public IEnumerable<ApplicationUser> allUser { get; set; }
	}
}

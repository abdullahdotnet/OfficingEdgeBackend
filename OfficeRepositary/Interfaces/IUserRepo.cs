using MySql.EntityFrameworkCore.Infrastructure.Internal;
using Office.DataLayer.Identity;
//using Office.DataLayer.Data;
using OfficeModels.Requests;
using OfficeModels.Responses;
using OfficeModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeRepositary.Interfaces
{
	public interface IUserRepo
	{
		Task<Response> punchIn(PunchRequest request);
		Task<Response> punchOut(PunchRequest request);
		Task<Response> GetUser(string id);
		Task<Response> GetAllUser();
		Task<Response> DeleteUser(string id);
	}
}

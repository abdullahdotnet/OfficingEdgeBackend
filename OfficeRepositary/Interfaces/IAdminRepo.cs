using Microsoft.AspNetCore.Mvc;
using Office.DataLayer.Data;
using OfficeModels.Responses;
using OfficeModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeRepositary.Interfaces
{
	public interface IAdminRepo
	{
		Task<Response> AddEmployee(NewEmployee user);
		Task<DepartmentList> GetDepartmentList();
		Task<IEnumerable<EmployeeType>> GetEmployeeTypesList();
		Task<Response> AddDepartment(Department dep);
		Task<Response> DeleteEmployee(int id);
		Task<Response> UpdateEmployee(int id);
	}
}

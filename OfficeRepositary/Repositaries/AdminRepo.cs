using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mysqlx;
using Office.DataLayer.data;
using OfficeModels.Responses;
using OfficeModels.ViewModels;
using OfficeRepositary.Interfaces;
using OfficeServices.Email;
using OfficeServices.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OfficeRepositary.Repositaries
{
	public class AdminRepo : IAdminRepo
	{
		private readonly db_a9696f_officeContext _db;
		private readonly ILogService _logger;
		private readonly IMailService _mailService;
		public AdminRepo(db_a9696f_officeContext db, ILogService logger, IMailService mailService)
		{
			_db = db;
			_logger = logger;
			_mailService = mailService;
		}

		public async Task<Response> AddDepartment(AddDepartment dep)
		{
			try
			{
				Department newDep = new Department();
				newDep.Name = dep.name;
				newDep.Description = dep.description;
				await _db.Departments.AddAsync(newDep);
				return new Response { Message = "Department is successfully added" };
			}
			catch (Exception ex)
			{
				_logger.LogError($"Exception occured in AddDepartment Api\n{ex.Message}");
				throw;
			}


		}
		#region
		//public async Task<Response> AddEmployee(NewEmployee user)
		//{
		//	string GeneratePassword()
		//	{
		//		Random random = new Random();
		//		string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
		//		string password = "";
		//		for (int i = 0; i < 8; i++)
		//		{
		//			password += characters[random.Next(characters.Length)];
		//		}
		//		return password;
		//	}
		//	try
		//	{
		//		Employee employee = new Employee();
		//		employee.EmpFirstName = user.firstName;
		//		employee.EmpLastName = user.lastName;
		//		employee.EmpEmail = user.email;
		//		employee.EmpPassword = GeneratePassword();
		//		employee.EmpDepId = user.department;
		//		employee.EmpTypeId = user.type;
		//		employee.HireDate = DateTime.Now.Date;
		//		await _db.Employees.AddAsync(employee);
		//		_db.SaveChanges();
		//		await _mailService.SendMailAsync(user.email, "Officing Edge Credentials", $"Email: {user.email}\nPassword: {employee.EmpPassword}");
		//		return new Response { Message = "Employee is successfully added" }; ;

		//	}
		//	catch (Exception ex)
		//	{
		//		_logger.LogError($"Exception occured in AddEmployee Api\n{ex.Message}");
		//		return new Response
		//		{
		//			StatusCode = System.Net.HttpStatusCode.BadRequest,
		//			ErrorMessages = new List<string> { "Failed to send email", ex.Message.ToString() }
		//		};
		//	}

		//}
		#endregion
		public async Task<DepartmentList> GetDepartmentList()
		{
			try
			{
				DepartmentList list = new DepartmentList();
				var response = await _db.Departments.ToListAsync();
				list.departmentList = response;
				return list;

			}
			catch (Exception ex)
			{
				_logger.LogError($"Exception occured in GetDepartmentList Api\n{ex.Message}");
				throw;
			}

		}
		#region
		//public async Task<IEnumerable<EmployeeType>> GetEmployeeTypesList()
		//{
		//	try
		//	{
		//		return await _db.EmployeeTypes.ToListAsync();
		//	}
		//	catch (Exception ex)
		//	{
		//		_logger.LogError($"Exception occured in GetEmployeeTypesList Api\n{ex.Message}");
		//		throw;
		//	}

		//}
		#endregion
		#region
		public async Task<Response> DeleteEmployee(int id)
		{
			try
			{
				var record = _db.Employees.FirstOrDefault(x => x.EmpId == id);
				if (record != null)
				{
					_db.Employees.Remove(record);
					await _db.SaveChangesAsync();
					return new Response { Message = "Employee is successfully deleted" };

				}
				else
				{
					return new Response { Message = "Employee not found" };
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($"Failed to delete employee\n{ex.Message}");
				return new Response { ErrorMessages = new List<string> { "failed to delete employee", ex.Message } };

			}

		}
		#endregion
		#region
		//public Task<Response> UpdateEmployee(int id)
		//{
		//	return null;
		//}
		#endregion
	}
}

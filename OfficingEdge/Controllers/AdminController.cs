using CollectCoModels.Response;
using CollectCoRepositry.Controllers;
using Microsoft.AspNetCore.Mvc;
using Office.DataLayer.data;
using OfficeModels.Requests;
using OfficeModels.Responses;
using OfficeModels.ViewModels;
using OfficeRepositary.Interfaces;
using OfficeServices.Log;
using System.Net;

namespace OfficingEdge.Controllers
{
	[ApiController]
	[Route("/")]

	public class AdminController : BaseController
	{
		private readonly IAdminRepo _admin;
		private readonly ILogService _logger;
		public AdminController(IAdminRepo admin, ILogService logger)
		{
			logger = _logger;
			_admin = admin;
		}
		[HttpPost("AddDepartment")]
		public async Task<ActionResult<ResponseDto>> AddDepartment(AddDepartment department)
		{
			if (!ModelState.IsValid)
				return GetResponse(new Response { StatusCode = HttpStatusCode.BadRequest, ErrorMessages = new() { "Request Not Valid" } });

			var response = await _admin.AddDepartment(department);
			return GetResponse(response);
		}
		#region
		//[HttpPost("AddEmployee")]
		//public async Task<ActionResult<ResponseDto>> AddEmployee(NewEmployee user)
		//{


		//	var response = await _admin.AddEmployee(user);
		//	return GetResponse(response);

		//}
		#endregion
		[HttpGet("GetDepartmentList")]
		[ProducesResponseType(typeof(DepartmentList), StatusCodes.Status200OK)]
		public async Task<ActionResult<ResponseDto>> GetDepartmentList()
		{

			var response = await _admin.GetDepartmentList();
			return GetResponse(response);

		}
		#region
		//[HttpDelete("DeleteEmployee/{emp_id}")]
		//public async Task<ActionResult<ResponseDto>> DeleteEmployee(int emp_id)
		//{
		//	var response = await _admin.DeleteEmployee(emp_id);
		//	return GetResponse(response);
		//}
		#endregion

	}
}

using CollectCoModels.Response;
using CollectCoRepositry.Controllers;
using Microsoft.AspNetCore.Mvc;
using OfficeModels.ViewModels;
using OfficeRepositary.Interfaces;
using OfficeServices.Log;

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
		[HttpPost("AddEmployee")]
		public async Task<ActionResult<ResponseDto>> AddEmployee(NewEmployee user)
		{


			var response = await _admin.AddEmployee(user);
			return GetResponse(response);

		}
		[HttpGet("GetDepartmentList")]
		[ProducesResponseType(typeof(DepartmentList), StatusCodes.Status200OK)]
		public async Task<ActionResult<ResponseDto>> GetDepartmentList()
		{

			var response = await _admin.GetDepartmentList();
			return GetResponse(response);

		}
		[HttpDelete("DeleteEmployee/{emp_id}")]
		public async Task<ActionResult<ResponseDto>> DeleteEmployee(int emp_id)
		{
			var response = await _admin.DeleteEmployee(emp_id);
			return GetResponse(response);
		}

	}
}

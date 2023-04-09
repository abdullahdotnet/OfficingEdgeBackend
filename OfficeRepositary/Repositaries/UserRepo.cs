using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Office.DataLayer.data;
using Office.DataLayer.Identity;
using OfficeModels.Requests;
using OfficeModels.Responses;
using OfficeModels.ViewModels;
using OfficeRepositary.Interfaces;
using OfficeServices.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeRepositary.Repositaries
{
	public class UserRepo : IUserRepo
	{
		private readonly db_a9696f_officeContext _context;
		private readonly ILogService _log;
		UserManager<ApplicationUser> _userManager;
		public UserRepo(db_a9696f_officeContext context, ILogService log, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_log = log;
			_userManager = userManager;
		}

		public async Task<Response> DeleteUser(string id)
		{
			try
			{
				var user = await _userManager.FindByIdAsync(id);
				if (user != null)
				{
					_context.Users.Remove(user);
					await _context.SaveChangesAsync();
					return new Response { Message = "User successfully deleted" };
				}
				return new Response { Message = "User not found" };
			}
			catch(Exception ex)
			{
				_log.LogError($"Error occur in Delete user api \n {ex.Message}");
				return new Response { ErrorMessages = { $"Error occur \n {ex.Message}" } };
			}
			
			
			 
		}

		public async Task<Response> GetAllUser()
		{
			try
			{
				UserList userlist = new UserList();
				userlist.allUser = await _context.Users.ToListAsync();
				return userlist;
			}
			catch (Exception ex)
			{
				_log.LogError($"Error occur in GetAllUser Api \n{ex.Message}");
				return new Response { ErrorMessages = { $"Error occur \n{ex.Message}" } };
			}
		}

		public async Task<Response> GetUser(string id)
		{
			try
			{
				UserVM obj = new UserVM();
			    obj.user = await _userManager.FindByIdAsync(id);
				return obj;
			}
			catch (Exception ex)
			{
				_log.LogError($"Error occur in GetUser Api \n{ex.Message}");
				return new Response { ErrorMessages = { $"Error occur \n{ex.Message}" } };
			}
		}
		public async Task<Response> punchIn(PunchRequest punchreq)
		{
			try
			{
				Punch punch = new Punch();
				punch.PuTypeId = punchreq.typeId;
				punch.PuTime = DateTime.Now;
				punch.PuType = punchreq.typeId == 1 ? "Check-In" : "Check-Out";
				punch.PuUserId = punchreq.empId;
				await _context.Punches.AddAsync(punch);
				await _context.SaveChangesAsync();
				return new Response { };
			}
			catch (Exception ex)
			{
				_log.LogError($"Exception occured in punchIn Api\n{ex.Message}");
				return new Response { ErrorMessages = new List<string> { "failed to create punch", ex.Message } };
			}

		}

		public async Task<Response> punchOut(PunchRequest punchreq)
		{

			try
			{
				var checkin = _context.Punches.OrderByDescending(x => x.PuTime).FirstOrDefault();
				Punch punch = new Punch();
				punch.PuTypeId = punchreq.typeId;
				punch.PuTime = DateTime.Now;
				punch.PuType = punchreq.typeId == 1 ? "Check-In" : "Check-Out";
				punch.PuUserId = punchreq.empId;
				await _context.Punches.AddAsync(punch);
				await _context.SaveChangesAsync();
				return new Response { };
			}
			catch (Exception ex)
			{
				_log.LogError($"Exception occured in punchIn Api\n{ex.Message}");
				return new Response { ErrorMessages = new List<string> { "failed to create punch", ex.Message } };
			}
		}
	}
}

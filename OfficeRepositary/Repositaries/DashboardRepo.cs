using Microsoft.EntityFrameworkCore;
using Office.DataLayer.data;
using OfficeRepositary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeRepositary.Repositaries
{
	public class DashboardRepo : IDashboardRepo
	{
		private readonly db_a9696f_officeContext _context;
		public DashboardRepo(db_a9696f_officeContext context)
		{
			_context = context;
		}
		public async Task<int> GetAbsents()
		{

			DateTime date = DateTime.Now;
			DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
			var absents = await _context.Absents
				.Where(x => x.AbDate >= firstDayOfMonth && x.AbDate <= DateTime.Now)
				.CountAsync();
			return absents;
		}

	}
}

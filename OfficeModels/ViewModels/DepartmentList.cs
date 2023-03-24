using Office.DataLayer.Data;
using OfficeModels.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeModels.ViewModels
{
	public class DepartmentList : Response
	{
		public IEnumerable<Department> departmentList { get; set; }

	}

}

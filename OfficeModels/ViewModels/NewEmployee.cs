using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeModels.ViewModels
{
	public class NewEmployee
	{
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string email { get; set; }
		public int department { get; set; }
		public int type { get; set; }
	}
}

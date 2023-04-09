using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Office.DataLayer.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office.DataLayer
{
	public class DatabaseContext : IdentityDbContext<ApplicationUser>
	{
		public DatabaseContext()
		{

		}
		public DatabaseContext(DbContextOptions<DatabaseContext> options)
			: base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}

using System;
using System.Collections.Generic;

namespace Office.DataLayer.data
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

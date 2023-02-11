using System;
using System.Collections.Generic;

namespace OfficingEdge.Data
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            Employees = new HashSet<Employee>();
        }

        public int EmpTypeId { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

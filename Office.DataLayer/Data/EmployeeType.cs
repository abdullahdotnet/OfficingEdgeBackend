using System;
using System.Collections.Generic;

namespace Office.DataLayer.data
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            Employees = new HashSet<Employee>();
        }

        public int EmpTypeId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace OfficingEdge.Data
{
    public partial class Punch
    {
        public int PuId { get; set; }
        public string? PuType { get; set; }
        public DateTime? PuTime { get; set; }
        public int PuTypeId { get; set; }
        public int EmployeesEmpId { get; set; }

        public virtual Employee EmployeesEmp { get; set; } = null!;
        public virtual PunchType PuTypeNavigation { get; set; } = null!;
    }
}

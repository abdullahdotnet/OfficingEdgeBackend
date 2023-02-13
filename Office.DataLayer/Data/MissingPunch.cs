using System;
using System.Collections.Generic;

namespace Office.DataLayer.Data
{
    public partial class MissingPunch
    {
        public int MpId { get; set; }
        public string? MpEmpId { get; set; }
        public string? MpType { get; set; }
        public DateTime? MpExpectedTime { get; set; }
        public DateTime? MpDate { get; set; }
        public int EmployeesEmpId { get; set; }

        public virtual Employee EmployeesEmp { get; set; } = null!;
    }
}

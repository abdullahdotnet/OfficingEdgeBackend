using System;
using System.Collections.Generic;

namespace Office.DataLayer.Data
{
    public partial class Employee
    {
        public Employee()
        {
            Absents = new HashSet<Absent>();
            Leaves = new HashSet<Leave>();
            MissingPunches = new HashSet<MissingPunch>();
            Presents = new HashSet<Present>();
            Punches = new HashSet<Punch>();
        }

        public int EmpId { get; set; }
        public string? EmpFirstName { get; set; }
        public string? EmpLastName { get; set; }
        public string? EmpEmail { get; set; }
        public string? EmpPassword { get; set; }
        public string? EmpPhoneNo { get; set; }
        public string? ManagerId { get; set; }
        public DateTime? HireDate { get; set; }
        public int EmpDepId { get; set; }
        public int EmpTypeId { get; set; }

        public virtual Department EmpDep { get; set; } = null!;
        public virtual EmployeeType EmpType { get; set; } = null!;
        public virtual ICollection<Absent> Absents { get; set; }
        public virtual ICollection<Leave> Leaves { get; set; }
        public virtual ICollection<MissingPunch> MissingPunches { get; set; }
        public virtual ICollection<Present> Presents { get; set; }
        public virtual ICollection<Punch> Punches { get; set; }
    }
}

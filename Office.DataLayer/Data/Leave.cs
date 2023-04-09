using System;
using System.Collections.Generic;

namespace Office.DataLayer.data
{
    public partial class Leave
    {
        public int LeId { get; set; }
        public int LeEmpId { get; set; }
        public DateTime? LeApplyingDate { get; set; }
        public DateTime? LeApplyForDate1 { get; set; }
        public DateTime? LeApplyForDate2 { get; set; }
        public ulong? LeApprove { get; set; }
        public int? LeApplyToEmpId { get; set; }

        public virtual Employee LeEmp { get; set; } = null!;
    }
}

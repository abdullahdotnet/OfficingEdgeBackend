using System;
using System.Collections.Generic;

namespace OfficingEdge.Data
{
    public partial class Absent
    {
        public int AbId { get; set; }
        public int AbEmpId { get; set; }
        public DateTime? AbDate { get; set; }

        public virtual Employee AbEmp { get; set; } = null!;
    }
}

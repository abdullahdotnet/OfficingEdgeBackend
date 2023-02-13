using System;
using System.Collections.Generic;

namespace Office.DataLayer.Data
{
    public partial class Absent
    {
        public int AbId { get; set; }
        public int AbEmpId { get; set; }
        public DateTime? AbDate { get; set; }

        public virtual Employee AbEmp { get; set; } = null!;
    }
}

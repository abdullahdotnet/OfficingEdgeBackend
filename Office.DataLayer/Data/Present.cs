using System;
using System.Collections.Generic;

namespace Office.DataLayer.Data
{
    public partial class Present
    {
        public int PrId { get; set; }
        public int PrEmpId { get; set; }
        public DateTime? PrDate { get; set; }
        public decimal? PrWorkedHours { get; set; }

        public virtual Employee PrEmp { get; set; } = null!;
    }
}

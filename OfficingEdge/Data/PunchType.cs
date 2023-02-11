using System;
using System.Collections.Generic;

namespace OfficingEdge.Data
{
    public partial class PunchType
    {
        public PunchType()
        {
            Punches = new HashSet<Punch>();
        }

        public int PunchTypeId { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<Punch> Punches { get; set; }
    }
}

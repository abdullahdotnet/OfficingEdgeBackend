using System;
using System.Collections.Generic;

namespace Office.DataLayer.data
{
    public partial class Punch
    {
        public int PuId { get; set; }
        public string? PuType { get; set; }
        public DateTime? PuTime { get; set; }
        public int PuTypeId { get; set; }
        public string? PuUserId { get; set; }

        public virtual PunchType PuTypeNavigation { get; set; } = null!;
    }
}

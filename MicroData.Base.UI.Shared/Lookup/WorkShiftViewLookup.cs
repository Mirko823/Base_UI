using MicroData.Common.UI.Shared.Lookup;
using System;

namespace MicroData.Base.UI.Shared.Lookup
{
    public  class WorkShiftViewLookup : BaseGuidViewLookup
    {
        public string? Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}

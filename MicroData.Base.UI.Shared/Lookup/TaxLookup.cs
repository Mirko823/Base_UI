using MicroData.Common.UI.Shared.Lookup;

namespace MicroData.Base.UI.Shared.Lookup
{
    public  class TaxLookup : BaseIntLookup
    {
        public short Type { get; set; }
        public string? Label { get; set; }
        public decimal Rate { get; set; }
    }
}

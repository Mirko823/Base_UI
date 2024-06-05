

using MicroData.Common.UI.Shared.ViewModel;
using System;

namespace MicroData.Base.UI.Shared.Lookup
{
    public  class BusinessPartnerSmallViewLookup : BaseViewModel<Guid>
    {
        public string? Code { get; set; }

        public string? Name { get; set; }

        public string? TaxNumber { get; set; }

        public bool IsActive { get; set; }
    }
}

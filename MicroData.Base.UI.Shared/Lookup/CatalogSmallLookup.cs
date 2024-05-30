using MicroData.Common.UI.Shared.ViewModel;
using System;

namespace MicroData.Base.UI.Shared.Lookup
{
    public  class CatalogSmallLookup : BaseViewModel<Guid>
    {
        public string? Code { get; set; }

        public string? Name { get; set; }

        public string? Unit { get; set; }
    }
}

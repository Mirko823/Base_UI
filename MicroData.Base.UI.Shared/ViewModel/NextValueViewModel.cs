using MicroData.Common.UI.Shared.ViewModel;
using System;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public partial class NextValueViewModel : BaseViewModel<int>
    {
        public Guid TenantId { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string Field { get; set; }
        public string Format { get; set; }
        public int Value { get; set; }
        public bool IsActive { get; set; }
    }
}

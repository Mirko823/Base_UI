using MicroData.Base.UI.Resource;
using MicroData.Common.UI.Resource;
using MicroData.Common.UI.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public partial class LocationViewModel : BaseViewModel<Guid>
    {
        [Display(AutoGenerateField = false)]
        public Guid TenantId { get; set; }

        [Display(AutoGenerateField = false)]
        public Guid CompanyId { get; set; }

        [Display(AutoGenerateField = false)]
        public byte LocationType { get; set; }

        [Display(Name = "Code", ResourceType = typeof(CommonStrings))]
        public string Code { get; set; } = null!;

        [Display(Name = "Name", ResourceType = typeof(CommonStrings))]
        public string Name { get; set; } = null!;

        [Display(AutoGenerateField = false)]
        public virtual ICollection<WarehouseViewModel> Warehouses { get; set; } = new List<WarehouseViewModel>();
    }
}

using MicroData.Common.UI.Resource;
using MicroData.Common.UI.Shared.ViewModel;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public class WarehouseViewModel : BaseAuditViewModel<Guid>
    {   
        [Display(AutoGenerateField = false)]
        public Guid TenantId { get; set; }

        [Display(AutoGenerateField = false)]
        public Guid CompanyId { get; set; }

        [Display(AutoGenerateField = false)]
        public int? ExportId { get; set; }

        [Display(AutoGenerateField = false)]
        public int WarehouseTypeId { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Type", ResourceType = typeof(CommonStrings))]
        public string WarehouseType { get; set; }

        [Display(Name = "Code", ResourceType = typeof(CommonStrings))]
        public string? Code { get; set; }

        [Display(Name = "Name", ResourceType = typeof(CommonStrings))]
        public string? Name { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(CommonStrings))]
        public bool? IsActive { get; set; }
    }
}

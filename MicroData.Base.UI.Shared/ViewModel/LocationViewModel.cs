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
        [Required]
        [Display(AutoGenerateField = false)]
        public Guid TenantId { get; set; }

        [Required]
        [Display(AutoGenerateField = false)]
        public Guid CompanyId { get; set; }

        [Display(AutoGenerateField = false)]
        public byte LocationType { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Code", ResourceType = typeof(CommonStrings))]
        public string Code { get; set; } = null!;

        [Required]
        [Display(Name = "Name", ResourceType = typeof(CommonStrings))]
        public string Name { get; set; } = null!;

        [Display(Name = "Address", ResourceType = typeof(CommonStrings))]
        public string? Address { get; set; }

        [Required]
        [Display(Name = "City", ResourceType = typeof(CommonStrings))]
        public string City { get; set; } = null!;

        [Display(Name = "State", ResourceType = typeof(CommonStrings))]
        public string? State { get; set; }

        [Display(Name = "IsDefault", ResourceType = typeof(CommonStrings))]
        public bool IsDefault { get; set; }

        [Display(AutoGenerateField = false)]
        public virtual List<WarehouseViewModel> Warehouses { get; set; } = new List<WarehouseViewModel>();
    }
}

using MicroData.Common.UI.Resource;
using MicroData.Common.UI.Shared.ViewModel;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public class WarehouseViewModel : BaseAuditViewModel<Guid>
    {
        [Required(ErrorMessage = "Zakupac je obavezno polje")]
        [Display(AutoGenerateField = false)]
        public Guid TenantId { get; set; }

        [Required(ErrorMessage = "Firma je obavezno polje")]
        [Display(AutoGenerateField = false)]
        public Guid CompanyId { get; set; }

        [Required(ErrorMessage = "Lokacija je obavezno polje")]
        [Display(AutoGenerateField = false)]
        public Guid LocationId { get; set; }

        [Display(AutoGenerateField = false)]
        public int? ExportId { get; set; }

        [Required(ErrorMessage = "Tip je obavezno polje")]
        [Display(AutoGenerateField = false)]      
        public int WarehouseTypeId { get; set; }


        [Display(Name = "Type", ResourceType = typeof(CommonStrings))]
        public string WarehouseType { get; set; }

        [Display(Name = "Code", ResourceType = typeof(CommonStrings))]
        public string? Code { get; set; }

        [Required(ErrorMessage = "Naziv je obavezno polje")]
        [Display(Name = "Name", ResourceType = typeof(CommonStrings))]
        public string? Name { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(CommonStrings))]
        public bool? IsActive { get; set; }
    }
}

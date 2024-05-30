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
        [Display(Name = "Tip", Order = 10)]
        public string WarehouseType { get; set; }

        [Display(Name = "Sifra", Order = 20)]
        public string Code { get; set; }

        [Display(Name = "Naziv", Order = 30)]
        public string Name { get; set; }

        [Display(Name = "Aktivan", Order = 40)]
        public bool? IsActive { get; set; }
    }
}

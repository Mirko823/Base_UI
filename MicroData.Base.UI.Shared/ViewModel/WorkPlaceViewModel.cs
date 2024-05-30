using MicroData.Common.UI.Shared.ViewModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public class WorkPlaceViewModel : BaseAuditViewModel<Guid>
    {
        [Display(AutoGenerateField = false)]
        public Guid TenantId { get; set; }

        [Display(AutoGenerateField = false)]
        public Guid CompanyId { get; set; }

        [Display(AutoGenerateField = false)]
        public Guid WarehouseId { get; set; }

        [Display(AutoGenerateField = false)]
        public int? ExportId { get; set; }

        [Display(AutoGenerateField = false)]
        //[Display(Name = "Magacin", Order = 10)]
        public string WarehouseName { get; set; }

        [Required(ErrorMessage = "Naziv je obavezno polje")]
        [Display(Name = "Naziv", Order = 10)]
        public string Name { get; set; }



    }
}

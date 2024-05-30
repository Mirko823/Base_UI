using MicroData.Common.UI.Shared.ViewModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public  class ProfessionViewModel : BaseAuditViewModel<Guid>
    {
        [Display(AutoGenerateField = false)]
        public Guid TenantId { get; set; }

        [Display(AutoGenerateField = false)]
        public Guid CompanyId { get; set; }

        [Display(AutoGenerateField = false)]
        public int? ExportId { get; set; }

        [Display(Name = "Šifra", Order = 10)]
        public string Code { get; set; }


        [Required(ErrorMessage = "Naziv je obavezno polje")]
        [Display(Name = "Naziv", Order = 20)]
        public string Name { get; set; }

    }
}

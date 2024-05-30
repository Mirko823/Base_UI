using MicroData.Common.UI.Shared.ViewModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public partial class WorkShiftViewModel : BaseViewModel<Guid>
    {
        [Display(AutoGenerateField = false, Name = "Firma")]
        public Guid TenantId { get; set; }

        [Display(AutoGenerateField = false)]
        public Guid CompanyId { get; set; }

        [Display(AutoGenerateField = false)]
        public int? ExportId { get; set; }

        [Display(Name = "Naziv")]
        public string Name { get; set; }

        [Display(Name = "Početak")]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "Kraj")]
        public TimeSpan EndTime { get; set; }

        [Display(Name = "Opis")]
        public string Descriptiom { get; set; }

    }
}

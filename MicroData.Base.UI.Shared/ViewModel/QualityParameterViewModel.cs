using MicroData.Common.UI.Resource;
using MicroData.Common.UI.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public partial class QualityParameterViewModel : BaseViewModel<int>
    {
        [Display(Name = "Name", ResourceType = typeof(CommonStrings))]
        public string? Name { get; set; }

        [Display(AutoGenerateField = false, Name = "Firma")]
        public virtual ICollection<CatalogQualityParameterViewModel> CatalogQualityParameters { get; set; } = new List<CatalogQualityParameterViewModel>();
    }
}

using MicroData.Common.UI.Resource;
using MicroData.Base.UI.Resource;
using MicroData.Common.UI.Shared.ViewModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public partial class CatalogQualityParameterViewModel : BaseViewModel<Guid>
    {
        [Display(AutoGenerateField = false)]
        public Guid CatalogId { get; set; }

        [Display(AutoGenerateField = false)]
        public int QualityParameterId { get; set; }

        [Display(Name = "QualityParameter", ResourceType = typeof(BaseStrings), AutoGenerateField = false)]
        public string? QualityParameter { get; set; }

        [Display(Name = "ValueFrom", ResourceType = typeof(BaseStrings), AutoGenerateField = false)]
        public decimal ValueFrom { get; set; }

        [Display(Name = "ValueTo", ResourceType = typeof(BaseStrings), AutoGenerateField = false)]
        public decimal ValueTo { get; set; }

        [Display(Name = "Description", ResourceType = typeof(BaseStrings), AutoGenerateField = false)]
        public string Description { get; set; } = null!;

        [Display(AutoGenerateField = false)]
        public virtual CatalogViewModel Catalog { get; set; } = null!;

        [Display(AutoGenerateField = false)]
        public virtual QualityParameterViewModel QualityParameterViewModel { get; set; } = null!;
    }
}
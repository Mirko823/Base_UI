using MicroData.Base.UI.Shared.Enum;
using MicroData.Common.UI.Shared.Lookup;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public  class GrainCatalogViewModel : CatalogViewModel    
    {
        [Display(AutoGenerateField = false)]
        public CatalogType Type => CatalogType.Grain;

        [Display(AutoGenerateField = false)]
        public  List<BaseIntViewLookup> AllQualityParameters { get; set; } = new List<BaseIntViewLookup>();

        [Display(AutoGenerateField = false)]
        public  List<CatalogQualityParameterViewModel> CatalogQualityParameters { get; set; } = new List<CatalogQualityParameterViewModel>();
    }
}

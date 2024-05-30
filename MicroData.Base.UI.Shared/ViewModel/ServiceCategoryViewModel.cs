using MicroData.Base.UI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public  class ServiceCategoryViewModel : CatalogCategoryViewModel
    {
        [Display(AutoGenerateField = false)]
        public CatalogType Type => CatalogType.Service;

    }
}

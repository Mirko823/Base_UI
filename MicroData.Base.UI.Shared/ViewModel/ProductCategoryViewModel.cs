using MicroData.Base.UI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public  class ProductCategoryViewModel : CatalogCategoryViewModel
    {
        [Display(AutoGenerateField = false)]
        public CatalogType Type => CatalogType.Product;

    }
}

using MicroData.Base.UI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public  class ProductCatalogViewModel : CatalogViewModel    
    {
        [Display(AutoGenerateField = false)]
        public CatalogType Type => CatalogType.Product;

    }
}

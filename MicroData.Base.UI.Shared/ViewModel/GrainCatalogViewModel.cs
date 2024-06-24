using MicroData.Base.UI.Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace MicroData.Base.UI.Shared.ViewModel
{
    public  class GrainCatalogViewModel : CatalogViewModel    
    {
        [Display(AutoGenerateField = false)]
        public CatalogType Type => CatalogType.Grain;


    }
}

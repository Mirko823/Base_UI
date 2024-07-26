using MicroData.Base.UI.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroData.Base.UI.Blazor.Pages.GrainCatalog
{
    public partial class GrainCatalogList
    {

        public List<GrainCatalogViewModel> GrainCatalogs { get; set; } = default!;

    }
}

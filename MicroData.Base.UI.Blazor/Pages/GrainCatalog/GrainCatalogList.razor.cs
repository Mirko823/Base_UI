using MicroData.Base.UI.Shared.Api;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroData.Base.UI.Blazor.Pages.GrainCatalog
{
    public partial class GrainCatalogList
    {
        [Inject]
        public IGrainCatalogApi _grainCatalogApi { get; set; }
        public List<GrainCatalogViewModel> GrainCatalogs { get; set; } = default!;

        protected override void OnInitialized()
        {
            GrainCatalogs = _grainCatalogApi.GetAll(string.Empty).ToList();
        }
    }
}

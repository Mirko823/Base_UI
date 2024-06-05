using MicroData.Base.UI.Shared.ViewModel;
using MicroData.Common.UI.Shared.Interface;
using System.Collections.Generic;

namespace MicroData.Base.UI.Shared.Interface
{
    public interface IGrainCatalogApi : IBaseApi<GrainCatalogViewModel>
    {
        IEnumerable<CatalogQualityParameterViewModel> GetQualityParameterByCatalogId(string catalogId, string accessToken);
    }
}

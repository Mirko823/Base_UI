using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;

namespace MicroData.Base.UI.Shared.Api
{
    public class GrainCatalogApi : BaseBaseApi<GrainCatalogViewModel> , IGrainCatalogApi
    {
      
        public GrainCatalogApi() : base()
        {
        }

        public override string Endpoint => "api/GrainCatalog";


    }
}

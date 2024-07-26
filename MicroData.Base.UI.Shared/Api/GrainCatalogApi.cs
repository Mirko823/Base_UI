using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;

namespace MicroData.Base.UI.Shared.Api
{
    public class GrainCatalog : BaseBaseApi<GrainCatalogViewModel> , IGrainCatalogApi
    {
      
        public GrainCatalog() : base()
        {
        }

        public override string Endpoint => "api/GrainCatalog";


    }
}

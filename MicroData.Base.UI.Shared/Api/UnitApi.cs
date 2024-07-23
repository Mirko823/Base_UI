using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;

namespace MicroData.Base.UI.Shared.Api
{
    public class UnitApi : BaseBaseApi<UnitViewModel> , IUnitApi
    {
      
        public UnitApi() : base()
        {
        }

        public override string Endpoint => "api/Unit";


    }
}

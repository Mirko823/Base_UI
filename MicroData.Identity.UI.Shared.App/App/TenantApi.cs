using MicroData.Identity.UI.Shared.Api;
using MicroData.Identity.UI.Shared.Interface;
using MicroData.Identity.UI.Shared.ViewModel;

namespace MicroData.Base.UI.Shared.Api
{
    public class TenantApi : BaseIdentityApi<TenantViewModel> , ITenantApi
    {
      
        public TenantApi() : base()
        {
        }

        public override string Endpoint => "api/Tenant";

    }
}

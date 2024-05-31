using AutoMapper;
using MicroData.Identity.Application.Interface;
using MicroData.Identity.Domain.Model;
using MicroData.Identity.UI.Shared.Api;
using MicroData.Identity.UI.Shared.Interface;
using MicroData.Identity.UI.Shared.ViewModel;

namespace MicroData.Base.UI.Shared.Api
{
    public class TenantApp : BaseIdentityApp<TenantViewModel,TenantModel> , ITenantApi
    {

        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        public TenantApp(ITenantService tenantService, IMapper mapper) : base(tenantService,mapper)
        {
            _tenantService = tenantService;
            _mapper = mapper;
        }

    }
}

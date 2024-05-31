using AutoMapper;
using MicroData.Base.Application.Interface;
using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.App.App;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;

namespace MicroData.Base.UI.Shared.Api
{
    public class BusinessPartnerApp : BaseBaseApp<BusinessPartnerViewModel, BusinessPartnerModel> , IBusinessPartnerApi
    {

        private readonly IBusinessPartnerService _businessPartnerService;
        private readonly IMapper _mapper;
        public BusinessPartnerApp(IBusinessPartnerService businessPartnerService, IMapper mapper) : base(businessPartnerService, mapper)
        {
            _businessPartnerService = businessPartnerService;
            _mapper = mapper;
        }


        //public override BusinessPartnerModel CreateNew(BusinessPartnerModel Model, string accessToken)
        //{
        //    var result = base.CreateNew(Model, accessToken);
        //    return result;
        //}

        //public override BusinessPartnerModel EditExisting(BusinessPartnerModel Model, string accessToken)
        //{

        //    var result = base.EditExisting(Model, accessToken);

        //    return result;
        //}

    }
}

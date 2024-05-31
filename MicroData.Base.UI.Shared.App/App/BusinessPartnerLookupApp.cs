using AutoMapper;
using MicroData.Base.Application.Interface;
using MicroData.Base.Domain.Lookup;
using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.App.App;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.Lookup;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroData.Base.UI.Shared.Api
{
    //public class BusinessPartnerLookupApp : BaseBaseApp<BusinessPartnerSmallLookupView,BusinessPartnerSmallLookup> , IBusinessPartnerLookupApi
    //{
      
    //    private readonly ILookupService _api;
    //    private readonly IMapper _mapper;

    //    public BusinessPartnerLookupApp(ILookupService api, IMapper mapper) : base(api,mapper)
    //    {
    //        _api = api;
    //        _mapper = mapper;
    //    }

    //    public override async Task<IEnumerable<BusinessPartnerSmallLookup>> GetAllAsync(string accessToken)
    //    {
    //        var _endpoint = _webHostApi + Endpoint + "/GetAllBusinessPartnersSmallAsync";

    //        var response = await _httpClient.SendAsync(GetRequestTemplate(HttpMethod.Get, _endpoint, accessToken));
    //        var body = await response.Content.ReadAsStringAsync();
    //        return JsonConvert.DeserializeObject<IEnumerable<BusinessPartnerSmallLookup>>(body);
    //    }

    //    public override IEnumerable<BusinessPartnerSmallLookup> GetAll(string accessToken)
    //    {
    //        var _endpoint = _webHostApi + Endpoint + "/GetAllBusinessPartnersSmall";

    //        var response = _httpClient.SendAsync(GetRequestTemplate(HttpMethod.Get, _endpoint, accessToken)).Result;
    //        var body = response.Content.ReadAsStringAsync().Result;
    //        return JsonConvert.DeserializeObject<IEnumerable<BusinessPartnerSmallLookup>>(body);
    //    }

    //}
}

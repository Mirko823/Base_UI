using AutoMapper;
using MicroData.Base.Application.Interface;
using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.App.App;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;

namespace MicroData.Base.UI.Shared.Api
{
    public class LocationApp : BaseBaseApp<LocationViewModel,LocationModel> , ILocationApi
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;
        public LocationApp(ILocationService locationService, IMapper mapper) : base(locationService, mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }


    }
}

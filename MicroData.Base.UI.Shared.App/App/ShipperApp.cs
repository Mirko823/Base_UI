using AutoMapper;
using MicroData.Base.Application.Interface;
using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.App.App;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;

namespace MicroData.Base.UI.Shared.Api
{
    public class ShipperApp : BaseBaseApp<ShipperViewModel,ShipperModel> , IShipperApi
    {
        private readonly IShipperService _shipperService;
        private readonly IMapper _mapper;
        public ShipperApp(IShipperService shipperService, IMapper mapper) : base(shipperService, mapper)
        {
            _shipperService = shipperService;
            _mapper = mapper;
        }


    }
}

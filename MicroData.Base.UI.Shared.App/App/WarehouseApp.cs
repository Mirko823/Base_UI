using AutoMapper;
using MicroData.Base.Application.Interface;
using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.App.App;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;

namespace MicroData.Base.UI.Shared.Api
{
    public class WarehouseApp : BaseBaseApp<WarehouseViewModel,WarehouseModel> , IWarehouseApi
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IMapper _mapper;
        public WarehouseApp(IWarehouseService warehouseService, IMapper mapper) : base(warehouseService,mapper)
        {
            _warehouseService = warehouseService;
            _mapper = mapper;
        }


    }
}

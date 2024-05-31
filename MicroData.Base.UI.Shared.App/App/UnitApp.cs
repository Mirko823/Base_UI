using AutoMapper;
using MicroData.Base.Application.Interface;
using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.App.App;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;

namespace MicroData.Base.UI.Shared.Api
{
    public class UnitApp : BaseBaseApp<UnitViewModel,UnitModel> , IUnitApi
    {

        private readonly IUnitService _unitService;
        private readonly IMapper _mapper;
        public UnitApp(IUnitService unitService, IMapper mapper) : base(unitService, mapper)
        {
            _unitService = unitService;
            _mapper = mapper;
        }

    }
}

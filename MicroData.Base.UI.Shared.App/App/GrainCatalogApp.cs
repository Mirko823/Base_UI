using AutoMapper;
using MicroData.Base.Application.Interface;
using MicroData.Base.Application.Service;
using MicroData.Base.Domain.Enum;
using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.App.App;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;

namespace MicroData.Base.UI.Shared.Api
{
    public class GrainCatalogApp : BaseBaseApp<GrainCatalogViewModel,GrainCatalogModel> , IGrainCatalogApi
    {
        private readonly IGrainCatalogService _grainCatalogService;
        private readonly IMapper _mapper;
        public GrainCatalogApp(IGrainCatalogService grainCatalogService, IMapper mapper) : base(grainCatalogService, mapper)
        {
            _grainCatalogService = grainCatalogService;
            _mapper = mapper;
        }


        public override IEnumerable<GrainCatalogViewModel> GetAll(string accessToken)
        {
            var result = _grainCatalogService.GetAllDapper();
            return _mapper.Map<IEnumerable<GrainCatalogViewModel>>(result);
        }

        public override async Task<IEnumerable<GrainCatalogViewModel>> GetAllAsync(string accessToken)
        {
            var result = await _grainCatalogService.GetAllDapperAsync();
            return _mapper.Map<IEnumerable<GrainCatalogViewModel>>(result);
        }

    }
}

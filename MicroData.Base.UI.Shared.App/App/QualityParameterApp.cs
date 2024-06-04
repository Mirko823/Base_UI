using AutoMapper;
using MicroData.Base.Application.Interface;
using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.App.App;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;

namespace MicroData.Base.UI.Shared.Api
{
    public class QualityParameterApp : BaseBaseApp<QualityParameterViewModel,QualityParameterModel> , IQualityParameterApi
    {
        private readonly IQualityParameterService _qualityParameterService;
        private readonly IMapper _mapper;
        public QualityParameterApp(IQualityParameterService qualityParameterService, IMapper mapper) : base(qualityParameterService, mapper)
        {
            _qualityParameterService = qualityParameterService;
            _mapper = mapper;
        }

       

    }
}

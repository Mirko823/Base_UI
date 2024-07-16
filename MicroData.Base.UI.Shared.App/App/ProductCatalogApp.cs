using AutoMapper;
using MicroData.Base.Application.Interface;
using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.App.App;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;

namespace MicroData.Base.UI.Shared.Api
{
    public class ProductCatalogApp : BaseBaseApp<ProductCatalogViewModel,ProductCatalogModel> , IProductCatalogApi
    {
        private readonly IProductCatalogService _productCatalogService;
        private readonly IMapper _mapper;
        public ProductCatalogApp(IProductCatalogService productCatalogService, IMapper mapper) : base(productCatalogService, mapper)
        {
            _productCatalogService = productCatalogService;
            _mapper = mapper;
        }

        public override IEnumerable<ProductCatalogViewModel> GetAll(string accessToken)
        {
            var result = _productCatalogService.GetAllDapper();
            return _mapper.Map<IEnumerable<ProductCatalogViewModel>>(result);
        }

        public override async Task<IEnumerable<ProductCatalogViewModel>> GetAllAsync(string accessToken)
        {
            var result = await _productCatalogService.GetAllDapperAsync();
            return _mapper.Map<IEnumerable<ProductCatalogViewModel>>(result);
        }

    }
}

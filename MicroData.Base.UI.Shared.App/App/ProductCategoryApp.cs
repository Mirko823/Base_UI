using AutoMapper;
using MicroData.Base.Application.Interface;
using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.App.App;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;

namespace MicroData.Base.UI.Shared.Api
{
    public class ProductCategoryApp : BaseBaseApp<ProductCategoryViewModel,ProductCategoryModel> , IProductCategoryApi
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IMapper _mapper;
        public ProductCategoryApp(IProductCategoryService productCategoryService, IMapper mapper) : base(productCategoryService, mapper)
        {
            _productCategoryService = productCategoryService;
            _mapper = mapper;
        }

    }
}

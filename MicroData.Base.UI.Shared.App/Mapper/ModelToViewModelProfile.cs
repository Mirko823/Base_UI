using AutoMapper;
using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.ViewModel;

namespace MicroData.Base.UI.Shared.App.Mapper
{
    public class ModelToViewModelProfile : Profile
    {
        public ModelToViewModelProfile()
        {
            CreateMap<BankModel, BankViewModel>();
            CreateMap<TaxModel, TaxViewModel>();
            CreateMap<UnitModel, UnitViewModel>();
            CreateMap<CityModel, CityViewModel>();
            CreateMap<CurrencyModel, CurrencyViewModel>();

            //CreateMap<RegisteredCompanyOnSefModel, RegisteredCompanyOnSef>();

            CreateMap<BusinessPartnerModel, BusinessPartnerViewModel>();

            CreateMap<CityModel, CityViewModel>();
            CreateMap<ClientModel, ClientViewModel>();

            CreateMap<EmployeeModel, EmployeeViewModel>();

            CreateMap<ProductCategoryModel, ProductCategoryViewModel>();
            CreateMap<ServiceCategoryModel, ProductCategoryViewModel>();

            CreateMap<ProductCatalogModel, ProductCatalogViewModel>(MemberList.Source);

            CreateMap<ServiceCatalogModel, ServiceCatalogViewModel>(MemberList.Source);

            CreateMap<ProfessionModel, ProfessionViewModel>();

            CreateMap<WarehouseModel, WarehouseViewModel>(MemberList.Source);

            CreateMap<WorkPlaceModel, WorkPlaceViewModel>();
            CreateMap<WorkShiftModel, WorkShiftViewModel>();

        }
    }
}

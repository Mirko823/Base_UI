using AutoMapper;
using MicroData.Base.Data.Entity;
using MicroData.Base.Domain.Lookup;
using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.Lookup;
using MicroData.Base.UI.Shared.ViewModel;
using MicroData.Common.Domain.Lookup;
using MicroData.Common.UI.Shared.Lookup;

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

            CreateMap<BusinessPartnerModel, BusinessPartnerViewModel>();

            CreateMap<CityModel, CityViewModel>();
            CreateMap<ClientModel, ClientViewModel>();

            CreateMap<EmployeeModel, EmployeeViewModel>();

            CreateMap<LocationModel, LocationViewModel>();
            CreateMap<ShipperModel, ShipperViewModel>();

            CreateMap<ProductCategoryModel, ProductCategoryViewModel>();
            CreateMap<ServiceCategoryModel, ServiceCategoryViewModel>();

            CreateMap<ProductCatalogModel, ProductCatalogViewModel>(MemberList.Source);
            CreateMap<ServiceCatalogModel, ServiceCatalogViewModel>(MemberList.Source);

            CreateMap<GrainCatalogModel, GrainCatalogViewModel>(MemberList.Source);

            CreateMap<ProfessionModel, ProfessionViewModel>();

            CreateMap<WarehouseModel, WarehouseViewModel>(MemberList.Source);

            CreateMap<WorkPlaceModel, WorkPlaceViewModel>();
            CreateMap<WorkShiftModel, WorkShiftViewModel>();

            CreateMap<BaseIntLookup, BaseIntViewLookup>();
            CreateMap<BaseGuidLookup, BaseGuidViewLookup>();

            CreateMap<BusinessPartnerSmallLookup, BusinessPartnerSmallViewLookup>();
            CreateMap<BusinessPartnerLookup, BusinessPartnerViewLookup>();
            CreateMap<ShipperLookup, ShipperViewLookup>();
            CreateMap<CatalogSmallLookup, CatalogSmallViewLookup>();
            CreateMap<CatalogLookup, CatalogViewLookup>();
            CreateMap<ClientSmallLookup, ClientSmallViewLookup>();
            CreateMap<ClientLookup, ClientViewLookup>();
            CreateMap<EmployeeLookup, EmployeeViewLookup>();
            CreateMap<TaxLookup, TaxViewLookup>();
            CreateMap<WorkShiftLookup, WorkShiftViewLookup>();
        }
    }
}

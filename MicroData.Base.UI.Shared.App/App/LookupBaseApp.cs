using AutoMapper;
using MicroData.Base.Application.Interface;
using MicroData.Base.Domain.Lookup;
using MicroData.Base.UI.Shared.Enum;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.Lookup;
using MicroData.Common.UI.Shared.Identity;
using MicroData.Common.UI.Shared.Lookup;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Net.Http;

namespace MicroData.Base.UI.Shared.Api
{
    public class LookupBaseApp : ILookupBaseApi
    {
        private readonly ILookupService _lookupService;
        private readonly IMapper _mapper;


        public LookupBaseApp( ILookupService lookupService
                            , IMapper mapper)
        { 
            CurrentSecurityUser = new Common.Domain.Model.SecurityUser()
            {
                TenantId = CurrentUser.TenantId.ToString(),
                ComapanyId = CurrentUser.ComapanyId.ToString(),
                UserId = CurrentUser.Id.ToString(),
                UserName = CurrentUser.UserName,
                Year = DateTime.Now.Year,
            };

            _lookupService = lookupService;
            _mapper = mapper;
        }

        #region Taxes
        public List<TaxViewLookup> GetAllTaxes(string accessToken)
        {
            var result = _lookupService.GetAllTaxes();
            return _mapper.Map<List<TaxViewLookup>>(result);
        }

        public async Task<IEnumerable<TaxViewLookup>> GetAllTaxesAsync(string accessToken)
        {
            var result = await _lookupService.GetAllTaxesAsync();
            return _mapper.Map<IEnumerable<TaxViewLookup>>(result);
        }
        #endregion

        #region Units
        public List<BaseIntViewLookup> GetAllUnit(string accessToken)
        {
            var result = _lookupService.GetAllUnit();
            return _mapper.Map<List<BaseIntViewLookup>>(result);
        }

        public async Task<IEnumerable<BaseIntViewLookup>> GetAllUnitAsync(string accessToken)
        {
            var result = await _lookupService.GetAllUnitAsync();
            return _mapper.Map<IEnumerable<TaxViewLookup>>(result);
        }
        #endregion

        #region QualityParameters
        public IEnumerable<BaseIntViewLookup> GetAllQualityParameter(string accessToken)
        {
            var result = _lookupService.GetAllQualityParameter();
            return _mapper.Map<List<BaseIntViewLookup>>(result);
        }

        public async Task<IEnumerable<BaseIntViewLookup>> GetAllQualityParameterAsync(string accessToken)
        {
            var result = await _lookupService.GetAllQualityParameterAsync();
            return _mapper.Map<IEnumerable<TaxViewLookup>>(result);
        }
        #endregion

        #region Cities
        public List<BaseIntViewLookup> GetAllCity(string accessToken)
        {
            var result = _lookupService.GetAllCity();
            return _mapper.Map<List<BaseIntViewLookup>>(result);
        }

        public async Task<IEnumerable<BaseIntViewLookup>> GetAllCityAsync(string accessToken)
        {
            var result = await _lookupService.GetAllCityAsync();
            return _mapper.Map<IEnumerable<TaxViewLookup>>(result);
        }
        #endregion

        #region States
        public List<BaseIntViewLookup> GetAllState(string accessToken)
        {
            var result = _lookupService.GetAllState();
            return _mapper.Map<List<BaseIntViewLookup>>(result);
        }

        public async Task<IEnumerable<BaseIntViewLookup>> GetAllStateAsync(string accessToken)
        {
            var result = await _lookupService.GetAllStateAsync();
            return _mapper.Map<IEnumerable<TaxViewLookup>>(result);
        }
        #endregion

        #region Categories
        public IEnumerable<BaseGuidViewLookup> GetAllCategories(string accessToken)
        {
            var result = _lookupService.GetAllState();
            return _mapper.Map<List<BaseGuidViewLookup>>(result);
        }

        public async Task<IEnumerable<BaseGuidViewLookup>> GetAllCategoriesAsync(string accessToken)
        {
            var result = await _lookupService.GetAllCategoriesAsync(CurrentSecurityUser);
            return _mapper.Map<IEnumerable<BaseGuidViewLookup>>(result);
        }
        #endregion

        #region Catalogs
        public IEnumerable<CatalogViewLookup> GetAllCatalogs(string accessToken)
        {
            var result = _lookupService.GetAllCatalogs(CurrentSecurityUser);
            return _mapper.Map< IEnumerable<CatalogViewLookup>>(result);
        }

        public async Task<IEnumerable<CatalogViewLookup>> GetAllCatalogsAsync(string accessToken)
        {
            var result = await _lookupService.GetAllCatalogsAsync(CurrentSecurityUser);
            return _mapper.Map<IEnumerable<CatalogViewLookup>>(result);
        }
        #endregion

        #region BusinessPartner
        public IEnumerable<BusinessPartnerViewLookup> GetAllBusinessPartners(string accessToken)
        {
            var result = _lookupService.GetAllBusinessPartners(CurrentSecurityUser);
            return _mapper.Map<IEnumerable<BusinessPartnerViewLookup>>(result);
        }

        public async Task<IEnumerable<BusinessPartnerViewLookup>> GetAllBusinessPartnerAsync(string accessToken)
        {
            var result = await _lookupService.GetAllBusinessPartnersAsync(CurrentSecurityUser);
            return _mapper.Map<IEnumerable<BusinessPartnerViewLookup>>(result);
        }

        public IEnumerable<BusinessPartnerSmallViewLookup> GetAllBusinessPartnersSmall(string accessToken)
        {
            var result = _lookupService.GetAllBusinessPartnersSmall(CurrentSecurityUser);
            return _mapper.Map<IEnumerable<BusinessPartnerSmallViewLookup>>(result);
        }

        public async Task<IEnumerable<BusinessPartnerSmallViewLookup>> GetAllBusinessPartnerSmallAsync(string accessToken)
        {
            var result = await _lookupService.GetAllBusinessPartnersSmallAsync(CurrentSecurityUser);
            return _mapper.Map<IEnumerable<BusinessPartnerSmallViewLookup>>(result);
        }
        #endregion

        #region Shipper
        public IEnumerable<ShipperViewLookup> GetAllShippers(string accessToken)
        {
            var result = _lookupService.GetAllShippers(CurrentSecurityUser);
            return _mapper.Map<IEnumerable<ShipperViewLookup>>(result);
        }

        public async Task<IEnumerable<ShipperViewLookup>> GetAllShipperAsync(string accessToken)
        {
            var result = await _lookupService.GetAllShippersAsync(CurrentSecurityUser);
            return _mapper.Map<IEnumerable<ShipperViewLookup>>(result);
        }
        #endregion

        #region Client
        public IEnumerable<ClientViewLookup> GetAllClients(string accessToken)
        {
            var result = _lookupService.GetAllClients(CurrentSecurityUser);
            return _mapper.Map<IEnumerable<ClientViewLookup>>(result);
        }

        public async Task<IEnumerable<ClientViewLookup>> GetAllClientAsync(string accessToken)
        {
            var result = await _lookupService.GetAllClientsAsync(CurrentSecurityUser);
            return _mapper.Map<IEnumerable<ClientViewLookup>>(result);
        }

        public IEnumerable<ClientSmallViewLookup> GetAllClientsSmall(string accessToken)
        {
            var result = _lookupService.GetAllClientsSmall(CurrentSecurityUser);
            return _mapper.Map<IEnumerable<ClientSmallViewLookup>>(result);
        }

        public async Task<IEnumerable<ClientSmallViewLookup>> GetAllClientSmallAsync(string accessToken)
        {
            var result = await _lookupService.GetAllClientsSmallAsync(CurrentSecurityUser);
            return _mapper.Map<IEnumerable<ClientSmallViewLookup>>(result);
        }
        #endregion

        #region Employee
        public List<EmployeeViewLookup> GetAllEmployee(string accessToken)
        {
            var result = _lookupService.GetAllEmployee();
            return _mapper.Map<List<EmployeeViewLookup>>(result);
        }

        public async Task<IEnumerable<EmployeeViewLookup>> GetAllEmployeeAsync(string accessToken)
        {
            var result = await _lookupService.GetAllEmployeeAsync();
            return _mapper.Map<IEnumerable<EmployeeViewLookup>>(result);
        }

        public List<EmployeeViewLookup> GetAllEmployeeCanSchedule(string accessToken)
        {
            var result = _lookupService.GetAllEmployeeCanSchedule();
            return _mapper.Map<List<EmployeeViewLookup>>(result);
        }

        public async Task<IEnumerable<EmployeeViewLookup>> GetAllEmployeeCanScheduleAsync(string accessToken)
        {
            var result = await _lookupService.GetAllEmployeeCanScheduleAsync();
            return _mapper.Map<IEnumerable<EmployeeViewLookup>>(result);
        }
        #endregion

        #region Profession
        public List<BaseGuidViewLookup> GetAllProfession(string accessToken)
        {
            var result = _lookupService.GetAllProfession();
            return _mapper.Map<List<BaseGuidViewLookup>>(result);
        }

        public async Task<IEnumerable<BaseGuidViewLookup>> GetAllProfessionAsync(string accessToken)
        {
            var result = await _lookupService.GetAllProfessionAsync();
            return _mapper.Map<IEnumerable<BaseGuidViewLookup>>(result);
        }
        #endregion

        #region Location
        public List<BaseGuidViewLookup> GetAllLocation(string accessToken)
        {
            var result = _lookupService.GetAllLocation();
            return _mapper.Map<List<BaseGuidViewLookup>>(result);
        }

        public async Task<IEnumerable<BaseGuidViewLookup>> GetAllLocationAsync(string accessToken)
        {
            var result = await _lookupService.GetAllLocationAsync();
            return _mapper.Map<IEnumerable<BaseGuidViewLookup>>(result);
        }
        #endregion

        #region WarehouseType

        public IEnumerable<BaseIntViewLookup> GetAllWarehouseType(string accessToken)
        {
            var result = _lookupService.GetAllWarehouseType();
            return _mapper.Map<IEnumerable<BaseIntViewLookup>>(result);
        }


        public async Task<IEnumerable<BaseIntViewLookup>> GetAllWarehouseTypeAsync(string accessToken)
        {
            var result = await _lookupService.GetAllWarehouseTypeAsync();
            return _mapper.Map<IEnumerable<BaseIntViewLookup>>(result);
        }

        #endregion

        #region WarehouseCode

        public IEnumerable<BaseGuidViewLookup> GetAllWarehouseCode(string accessToken)
        {
            var result = _lookupService.GetAllWarehouseCode();
            return _mapper.Map<IEnumerable<BaseGuidViewLookup>>(result);
        }

        public IEnumerable<BaseGuidViewLookup> GetAllWarehouseCode(WarehouseType warehouseType, string accessToken)
        {
            var result = _lookupService.GetAllWarehouseCode();
            return _mapper.Map<IEnumerable<BaseGuidViewLookup>>(result);
        }

        public async Task<IEnumerable<BaseGuidViewLookup>> GetAllWarehouseCodeAsync(string accessToken)
        {
            var result = await _lookupService.GetAllWarehouseCodeAsync();
            return _mapper.Map<IEnumerable<BaseGuidViewLookup>>(result);
        }



        public async Task<IEnumerable<BaseGuidViewLookup>> GetAllWarehouseCodeAsync(WarehouseType warehouseType, string accessToken)
        {
            var result = await _lookupService.GetAllWarehouseCodeAsync();
            return _mapper.Map<IEnumerable<BaseGuidViewLookup>>(result);
        }
        #endregion

        #region WarehouseName
        public IEnumerable<BaseGuidViewLookup> GetAllWarehouseName(string accessToken)
        {
            var result = _lookupService.GetAllWarehouseName();
            return _mapper.Map<IEnumerable<BaseGuidViewLookup>>(result);
        }

        public IEnumerable<BaseGuidViewLookup> GetAllWarehouseName(WarehouseType warehouseType, string accessToken)
        {
            var result = _lookupService.GetAllWarehouseName();
            return _mapper.Map<IEnumerable<BaseGuidViewLookup>>(result);
        }

        public async Task<IEnumerable<BaseGuidViewLookup>> GetAllWarehouseNameAsync(string accessToken)
        {
            var result = await _lookupService.GetAllWarehouseNameAsync();
            return _mapper.Map<IEnumerable<BaseGuidViewLookup>>(result);
        }

        public async Task<IEnumerable<BaseGuidViewLookup>> GetAllWarehouseNameAsync(WarehouseType warehouseType, string accessToken)
        {
            var result = await _lookupService.GetAllWarehouseNameAsync();
            return _mapper.Map<IEnumerable<BaseGuidViewLookup>>(result);
        }

        #endregion

        #region WorkPlace
        public List<BaseGuidViewLookup> GetAllWorkPlace(string accessToken)
        {
            var result = _lookupService.GetAllWorkPlace();
            return _mapper.Map<List<BaseGuidViewLookup>>(result);
        }

        public async Task<IEnumerable<BaseGuidViewLookup>> GetAllWorkPlaceAsync(string accessToken)
        {
            var result = await _lookupService.GetAllWorkPlaceAsync();
            return _mapper.Map<IEnumerable<BaseGuidViewLookup>>(result);
        }
        #endregion

        #region WorkShift
        public List<WorkShiftViewLookup> GetAllWorkShift(string accessToken)
        {
            var result = _lookupService.GetAllWorkShift();
            return _mapper.Map<List<WorkShiftViewLookup>>(result);
        }

        public async Task<IEnumerable<WorkShiftViewLookup>> GetAllWorkShiftAsync(string accessToken)
        {
            var result = await _lookupService.GetAllWorkShiftAsync();
            return _mapper.Map<IEnumerable<WorkShiftViewLookup>>(result);
        }
        #endregion

        #region Dates
        public List<BaseIntViewLookup> GetAllMonth()
        {
            var month = System.Globalization.CultureInfo.CurrentCulture
                        .DateTimeFormat.MonthGenitiveNames;

            var monthsLookup = new List<BaseIntViewLookup>();

            var i = 1;
            foreach (var monthName in month)
            {
                if (string.IsNullOrEmpty(monthName))
                { continue; }

                var monthLookup = new BaseIntViewLookup()
                {
                    Id = i,
                    Value = monthName
                };

                monthsLookup.Add(monthLookup);

                i++;
            }

            return monthsLookup;
        }

        #endregion

        #region SecurityUser

        private Common.Domain.Model.SecurityUser currentSecurityUser;

        public Common.Domain.Model.SecurityUser CurrentSecurityUser
        {
            get { return currentSecurityUser; }
            set { currentSecurityUser = value; }
        }

        #endregion
    }
}

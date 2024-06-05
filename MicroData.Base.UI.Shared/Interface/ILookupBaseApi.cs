using MicroData.Base.Domain.Lookup;
using MicroData.Base.UI.Shared.Enum;
using MicroData.Base.UI.Shared.Lookup;
using MicroData.Common.UI.Shared.Lookup;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroData.Base.UI.Shared.Interface
{
    public interface ILookupBaseApi
    {
        #region Taxes
        List<TaxViewLookup> GetAllTaxes(string accessToken);
        Task<IEnumerable<TaxViewLookup>> GetAllTaxesAsync(string accessToken);
        #endregion

        #region Unit
        List<BaseIntViewLookup> GetAllUnit(string accessToken);
        Task<IEnumerable<BaseIntViewLookup>> GetAllUnitAsync(string accessToken);
        #endregion

        #region Unit
        IEnumerable<BaseIntViewLookup> GetAllQualityParameter(string accessToken);
        Task<IEnumerable<BaseIntViewLookup>> GetAllQualityParameterAsync(string accessToken);
        #endregion

        #region City
        List<BaseIntViewLookup> GetAllCity(string accessToken);
        Task<IEnumerable<BaseIntViewLookup>> GetAllCityAsync(string accessToken);
        #endregion

        #region State
        List<BaseIntViewLookup> GetAllState(string accessToken);
        Task<IEnumerable<BaseIntViewLookup>> GetAllStateAsync(string accessToken);
        #endregion

        #region Categories
        IEnumerable<BaseGuidViewLookup> GetAllCategories(string accessToken);
        Task<IEnumerable<BaseGuidViewLookup>> GetAllCategoriesAsync(string accessToken);
        #endregion

        #region Catalogs
        IEnumerable<CatalogViewLookup> GetAllCatalogs(string accessToken);
        Task<IEnumerable<CatalogViewLookup>> GetAllCatalogsAsync(string accessToken);
        #endregion

        #region BusinessPartners
        IEnumerable<BusinessPartnerViewLookup> GetAllBusinessPartners(string accessToken);
        Task<IEnumerable<BusinessPartnerViewLookup>> GetAllBusinessPartnerAsync(string accessToken);

        IEnumerable<BusinessPartnerSmallViewLookup> GetAllBusinessPartnersSmall(string accessToken);
        Task<IEnumerable<BusinessPartnerSmallViewLookup>> GetAllBusinessPartnerSmallAsync(string accessToken);

        #endregion

        #region Clients
        IEnumerable<ClientViewLookup> GetAllClients(string accessToken);
        Task<IEnumerable<ClientViewLookup>> GetAllClientAsync(string accessToken);

        IEnumerable<ClientSmallViewLookup> GetAllClientsSmall(string accessToken);
        Task<IEnumerable<ClientSmallViewLookup>> GetAllClientSmallAsync(string accessToken);

        #endregion

        #region Employee
        List<EmployeeViewLookup> GetAllEmployee(string accessToken);
        Task<IEnumerable<EmployeeViewLookup>> GetAllEmployeeAsync(string accessToken);

        List<EmployeeViewLookup> GetAllEmployeeCanSchedule(string accessToken);
        Task<IEnumerable<EmployeeViewLookup>> GetAllEmployeeCanScheduleAsync(string accessToken);
        #endregion

        #region Profession
        List<BaseGuidViewLookup> GetAllProfession(string accessToken);
        Task<IEnumerable<BaseGuidViewLookup>> GetAllProfessionAsync(string accessToken);
        #endregion

        #region Location
        List<BaseGuidViewLookup> GetAllLocation(string accessToken);
        Task<IEnumerable<BaseGuidViewLookup>> GetAllLocationAsync(string accessToken);
        #endregion

        #region Warehouse Type
        IEnumerable<BaseIntViewLookup> GetAllWarehouseType(string accessToken);
        Task<IEnumerable<BaseIntViewLookup>> GetAllWarehouseTypeAsync(string accessToken);
        #endregion

        #region Warehouse
        IEnumerable<BaseGuidViewLookup> GetAllWarehouseCode(string accessToken);
        Task<IEnumerable<BaseGuidViewLookup>> GetAllWarehouseCodeAsync(string accessToken);

        IEnumerable<BaseGuidViewLookup> GetAllWarehouseCode(WarehouseType warehouseType, string accessToken);
        Task<IEnumerable<BaseGuidViewLookup>> GetAllWarehouseCodeAsync(WarehouseType warehouseType, string accessToken);

        IEnumerable<BaseGuidViewLookup> GetAllWarehouseName(string accessToken);
        Task<IEnumerable<BaseGuidViewLookup>> GetAllWarehouseNameAsync(string accessToken);

        IEnumerable<BaseGuidViewLookup> GetAllWarehouseName(WarehouseType warehouseType, string accessToken);
        Task<IEnumerable<BaseGuidViewLookup>> GetAllWarehouseNameAsync(WarehouseType warehouseType, string accessToken);
        #endregion

        #region WorkPlace
        List<BaseGuidViewLookup> GetAllWorkPlace(string accessToken);
        Task<IEnumerable<BaseGuidViewLookup>> GetAllWorkPlaceAsync(string accessToken);
        #endregion

        #region WorkShift
        List<WorkShiftViewLookup> GetAllWorkShift(string accessToken);
        Task<IEnumerable<WorkShiftViewLookup>> GetAllWorkShiftAsync(string accessToken);
        #endregion


        #region Dates
        List<BaseIntViewLookup> GetAllMonth();
        #endregion
    }
}

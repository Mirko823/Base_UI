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
        List<TaxLookup> GetAllTaxes(string accessToken);
        Task<IEnumerable<TaxLookup>> GetAllTaxesAsync(string accessToken);
        #endregion

        #region Unit
        List<BaseIntLookup> GetAllUnit(string accessToken);
        Task<IEnumerable<BaseIntLookup>> GetAllUnitAsync(string accessToken);
        #endregion

        #region City
        List<BaseIntLookup> GetAllCity(string accessToken);
        Task<IEnumerable<BaseIntLookup>> GetAllCityAsync(string accessToken);
        #endregion

        #region State
        List<BaseIntLookup> GetAllState(string accessToken);
        Task<IEnumerable<BaseIntLookup>> GetAllStateAsync(string accessToken);
        #endregion

        #region Categories
        IEnumerable<BaseGuidLookup> GetAllCategories(string accessToken);
        Task<IEnumerable<BaseGuidLookup>> GetAllCategoriesAsync(string accessToken);
        #endregion

        #region Catalogs
        IEnumerable<CatalogLookup> GetAllCatalogs(string accessToken);
        Task<IEnumerable<CatalogLookup>> GetAllCatalogsAsync(string accessToken);
        #endregion

        #region BusinessPartners
        IEnumerable<BusinessPartnerLookup> GetAllBusinessPartners(string accessToken);
        Task<IEnumerable<BusinessPartnerLookup>> GetAllBusinessPartnerAsync(string accessToken);

        IEnumerable<BusinessPartnerSmallLookupView> GetAllBusinessPartnersSmall(string accessToken);
        Task<IEnumerable<BusinessPartnerSmallLookupView>> GetAllBusinessPartnerSmallAsync(string accessToken);

        #endregion

        #region Clients
        IEnumerable<ClientLookup> GetAllClients(string accessToken);
        Task<IEnumerable<ClientLookup>> GetAllClientAsync(string accessToken);

        IEnumerable<ClientSmallLookup> GetAllClientsSmall(string accessToken);
        Task<IEnumerable<ClientSmallLookup>> GetAllClientSmallAsync(string accessToken);

        #endregion

        #region Employee
        List<EmployeeLookup> GetAllEmployee(string accessToken);
        Task<IEnumerable<EmployeeLookup>> GetAllEmployeeAsync(string accessToken);

        List<EmployeeLookup> GetAllEmployeeCanSchedule(string accessToken);
        Task<IEnumerable<EmployeeLookup>> GetAllEmployeeCanScheduleAsync(string accessToken);
        #endregion

        #region Profession
        List<BaseGuidLookup> GetAllProfession(string accessToken);
        Task<IEnumerable<BaseGuidLookup>> GetAllProfessionAsync(string accessToken);
        #endregion

        #region Warehouse Type
        IEnumerable<BaseIntLookup> GetAllWarehouseType(string accessToken);
        Task<IEnumerable<BaseIntLookup>> GetAllWarehouseTypeAsync(string accessToken);
        #endregion

        #region Warehouse
        IEnumerable<BaseGuidLookup> GetAllWarehouseCode(string accessToken);
        Task<IEnumerable<BaseGuidLookup>> GetAllWarehouseCodeAsync(string accessToken);

        IEnumerable<BaseGuidLookup> GetAllWarehouseCode(WarehouseType warehouseType, string accessToken);
        Task<IEnumerable<BaseGuidLookup>> GetAllWarehouseCodeAsync(WarehouseType warehouseType, string accessToken);

        IEnumerable<BaseGuidLookup> GetAllWarehouseName(string accessToken);
        Task<IEnumerable<BaseGuidLookup>> GetAllWarehouseNameAsync(string accessToken);

        IEnumerable<BaseGuidLookup> GetAllWarehouseName(WarehouseType warehouseType, string accessToken);
        Task<IEnumerable<BaseGuidLookup>> GetAllWarehouseNameAsync(WarehouseType warehouseType, string accessToken);
        #endregion

        #region WorkPlace
        List<BaseGuidLookup> GetAllWorkPlace(string accessToken);
        Task<IEnumerable<BaseGuidLookup>> GetAllWorkPlaceAsync(string accessToken);
        #endregion

        #region WorkShift
        List<WorkShiftLookup> GetAllWorkShift(string accessToken);
        Task<IEnumerable<WorkShiftLookup>> GetAllWorkShiftAsync(string accessToken);
        #endregion

        #region Dates
        List<BaseIntLookup> GetAllMonth();
        #endregion
    }
}

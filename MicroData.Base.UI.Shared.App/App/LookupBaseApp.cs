using MicroData.Base.Application.Interface;
using MicroData.Base.Domain.Enum;
using MicroData.Base.Domain.Lookup;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Common.Domain.Lookup;
using MicroData.Common.UI.Shared.Identity;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace MicroData.Base.UI.Shared.Api
{
    //public  class LookupBaseApp : ILookupBaseApi
    //{
    //    private readonly ILookupService _lookupService;
    //    private readonly IMemoryCache _memoryCache;

    //    public const string cacheKeyTaxes = "cacheKeyTaxes";
    //    public const string cacheKeyUnits = "cacheKeyUnits";
    //    public const string cacheKeyCities = "cacheKeyCities";
    //    public const string cacheKeyStates = "cacheKeyStates";
    //    public const string cacheKeyEmployee = "cacheKeyBaseEmployee";
    //    public const string cacheKeyEmployeeCanSchedule = "cacheKeyEmployeeCanSchedule";
    //    public const string cacheKeyCatalogCategories = "cacheKeyCatalogCategories";
    //    public const string cacheKeyProfession = "cacheKeyProfession";
    //    public const string cacheKeyWarehouseType = "cacheKeyWarehouseType";
    //    public const string cacheKeyWarehouseCode = "cacheKeyWarehouseCode";
    //    public const string cacheKeyWarehouseName = "cacheKeyWarehouseName";
    //    public const string cacheKeyWorkPlace = "cacheKeyWorkPlace";
    //    public const string cacheKeyWorkShift = "cacheKeyWorkShift";
    //    public const string cacheKeyWorkTask = "cacheKeyWorkTask";
    //    public const string cacheKeyWorkTaskSystem = "cacheKeyWorkTaskSystem";
    //    public const string cacheKeyWorkTaskNotSystem = "cacheKeyWorkTaskNotSystem";
    //    public const string cacheKeyRegisteredCompanyOnSEF = "cacheKeyRegisteredCompanyOnSEF";

    //    public LookupBaseApp(IMemoryCache memoryCache, ILookupService lookupService)
    //    {
    //        _memoryCache = memoryCache;
    //        _lookupService = lookupService;
    //    }

    //    #region Taxes
    //    public List<TaxLookup> GetAllTaxes(string accessToken)
    //    {
    //        List<TaxLookup> companyTaxes;

    //        if (_memoryCache.TryGetValue(cacheKeyTaxes, out companyTaxes))
    //        {
    //            return companyTaxes;
    //        }

    //        var allTaxes = _lookupService.GetAllTaxes();

    //        if (CurrentCompany.InVat)
    //            companyTaxes = allTaxes.Where(p => p.Type == (int)TaxType.InVat).ToList();
    //        else
    //            companyTaxes = allTaxes.Where(p => p.Type == (int)TaxType.NotInVat).ToList();

    //        _memoryCache.Set(cacheKeyTaxes, companyTaxes, TimeSpan.FromHours(6));

    //        return companyTaxes;
    //    }

    //    public async Task<IEnumerable<TaxLookup>> GetAllTaxesAsync(string accessToken)
    //    {
    //        List<TaxLookup> allTaxes;

    //        if (_memoryCache.TryGetValue(cacheKeyTaxes, out allTaxes))
    //        {
    //            return allTaxes;
    //        }

    //        allTaxes = await _lookupService.GetAllTaxesAsync().ToString();
            
    //        _memoryCache.Set(cacheKeyTaxes, allTaxes, TimeSpan.FromHours(6));
    //        return allTaxes;
    //    }
    //    #endregion

    //    #region Units
    //    public List<BaseIntLookup> GetAllUnit(string accessToken)
    //    {
    //        List<BaseIntLookup> allUnits;

    //        if (_memoryCache.TryGetValue(cacheKeyUnits, out allUnits))
    //        {
    //            return allUnits;
    //        }
            
    //        var body = this.GetAll("GetAllUnit", accessToken);
    //        allUnits = JsonConvert.DeserializeObject<List<BaseIntLookup>>(body);
    //        _memoryCache.Set(cacheKeyUnits, allUnits, TimeSpan.FromHours(6));
    //        return allUnits;
    //    }

    //    public async Task<IEnumerable<BaseIntLookup>> GetAllUnitAsync(string accessToken)
    //    {
    //        List<BaseIntLookup> allUnits;

    //        if (_memoryCache.TryGetValue(cacheKeyUnits, out allUnits))
    //        {
    //            return allUnits;
    //        }

    //        var body = await this.GetAllAsync("GetAllUnitAsync", accessToken);
    //        allUnits = JsonConvert.DeserializeObject<List<BaseIntLookup>>(body);
    //        _memoryCache.Set(cacheKeyUnits, allUnits, TimeSpan.FromHours(6));
    //        return allUnits;
    //    }
    //    #endregion

    //    #region Cities
    //    public List<BaseIntLookup> GetAllCity(string accessToken)
    //    {
    //        List<BaseIntLookup> allCities;

    //        if (_memoryCache.TryGetValue(cacheKeyCities, out allCities))
    //        {
    //            return allCities;
    //        }

    //        var body = this.GetAll("GetAllCity", accessToken);
    //        allCities = JsonConvert.DeserializeObject<List<BaseIntLookup>>(body);
    //        _memoryCache.Set(cacheKeyCities, allCities, TimeSpan.FromHours(6));
    //        return allCities;
    //    }

    //    public async Task<IEnumerable<BaseIntLookup>> GetAllCityAsync(string accessToken)
    //    {
    //        List<BaseIntLookup> allCities;

    //        if (_memoryCache.TryGetValue(cacheKeyCities, out allCities))
    //        {
    //            return allCities;
    //        }

    //        var body = await this.GetAllAsync("GetAllCityAsync", accessToken);
    //        allCities = JsonConvert.DeserializeObject<List<BaseIntLookup>>(body);
    //        _memoryCache.Set(cacheKeyCities, allCities, TimeSpan.FromHours(6));
    //        return allCities;
    //    }
    //    #endregion

    //    #region States
    //    public List<BaseIntLookup> GetAllState(string accessToken)
    //    {
    //        List<BaseIntLookup> allStates;

    //        if (_memoryCache.TryGetValue(cacheKeyStates, out allStates))
    //        {
    //            return allStates;
    //        }

    //        var body = this.GetAll("GetAllState", accessToken);
    //        allStates = JsonConvert.DeserializeObject<List<BaseIntLookup>>(body);
    //        _memoryCache.Set(cacheKeyStates, allStates, TimeSpan.FromHours(6));
    //        return allStates;
    //    }

    //    public async Task<IEnumerable<BaseIntLookup>> GetAllStateAsync(string accessToken)
    //    {
    //        List<BaseIntLookup> allStates;

    //        if (_memoryCache.TryGetValue(cacheKeyStates, out allStates))
    //        {
    //            return allStates;
    //        }

    //        var body = await this.GetAllAsync("GetAllStateAsync", accessToken);
    //        allStates = JsonConvert.DeserializeObject<List<BaseIntLookup>>(body);
    //        _memoryCache.Set(cacheKeyStates, allStates, TimeSpan.FromHours(6));
    //        return allStates;
    //    }
    //    #endregion

    //    #region Categories
    //    public IEnumerable<BaseGuidLookup> GetAllCategories(string accessToken)
    //    {
    //        List<BaseGuidLookup> allCategories;

    //        if (_memoryCache.TryGetValue(cacheKeyCatalogCategories, out allCategories))
    //        {
    //            return allCategories;
    //        }

    //        var body = this.GetAll("GetAllCategories", accessToken);
    //        allCategories = JsonConvert.DeserializeObject<List<BaseGuidLookup>>(body);
    //        _memoryCache.Set(cacheKeyCatalogCategories, allCategories, TimeSpan.FromHours(6));
    //        return allCategories;
    //    }

    //    public async Task<IEnumerable<BaseGuidLookup>> GetAllCategoriesAsync(string accessToken)
    //    {
    //        List<BaseGuidLookup> allCategories;

    //        if (_memoryCache.TryGetValue(cacheKeyCatalogCategories, out allCategories))
    //        {
    //            return allCategories;
    //        }

    //        var body = await this.GetAllAsync("GetAllCategoriesAsync", accessToken);
    //        allCategories = JsonConvert.DeserializeObject<List<BaseGuidLookup>>(body);
    //        _memoryCache.Set(cacheKeyCatalogCategories, allCategories, TimeSpan.FromHours(6));
    //        return allCategories;
    //    }
    //    #endregion

    //    #region Catalogs
    //    public IEnumerable<CatalogLookup> GetAllCatalogs(string accessToken)
    //    {
    //        var body = this.GetAll("GetAllCatalogs", accessToken);
    //        return JsonConvert.DeserializeObject<IEnumerable<CatalogLookup>>(body);
    //    }

    //    public async Task<IEnumerable<CatalogLookup>> GetAllCatalogsAsync(string accessToken)
    //    {
    //        var body = await this.GetAllAsync("GetAllCatalogsAsync", accessToken);
    //        return JsonConvert.DeserializeObject<IEnumerable<CatalogLookup>>(body);
    //    }
    //    #endregion


    //    #region BusinessPartner
    //    public IEnumerable<BusinessPartnerLookup> GetAllBusinessPartners(string accessToken)
    //    {
    //        var body = this.GetAll("GetAllBusinessPartners", accessToken);
    //        return JsonConvert.DeserializeObject<IEnumerable<BusinessPartnerLookup>>(body);
    //    }

    //    public async Task<IEnumerable<BusinessPartnerLookup>> GetAllBusinessPartnerAsync(string accessToken)
    //    {
    //        var body = await this.GetAllAsync("GetAllBusinessPartnersAsync", accessToken);
    //        return JsonConvert.DeserializeObject<IEnumerable<BusinessPartnerLookup>>(body);
    //    }

    //    public IEnumerable<BusinessPartnerSmallLookup> GetAllBusinessPartnersSmall(string accessToken)
    //    {
    //        var body = this.GetAll("GetAllBusinessPartnersSmall", accessToken);
    //        return JsonConvert.DeserializeObject<IEnumerable<BusinessPartnerSmallLookup>>(body);
    //    }

    //    public async Task<IEnumerable<BusinessPartnerSmallLookup>> GetAllBusinessPartnerSmallAsync(string accessToken)
    //    {
    //        var body = await this.GetAllAsync("GetAllBusinessPartnersSmallAsync", accessToken);
    //        return JsonConvert.DeserializeObject<IEnumerable<BusinessPartnerSmallLookup>>(body);
    //    }
    //    #endregion

    //    #region Client
    //    public IEnumerable<ClientLookup> GetAllClients(string accessToken)
    //    {
    //        var body = this.GetAll("GetAllClients", accessToken);
    //        return JsonConvert.DeserializeObject<IEnumerable<ClientLookup>>(body);
    //    }

    //    public async Task<IEnumerable<ClientLookup>> GetAllClientAsync(string accessToken)
    //    {
    //        var body = await this.GetAllAsync("GetAllClientsAsync", accessToken);
    //        return JsonConvert.DeserializeObject<IEnumerable<ClientLookup>>(body);
    //    }

    //    public IEnumerable<ClientSmallLookup> GetAllClientsSmall(string accessToken)
    //    {
    //        var body = this.GetAll("GetAllClientsSmall", accessToken);
    //        return JsonConvert.DeserializeObject<IEnumerable<ClientSmallLookup>>(body);
    //    }

    //    public async Task<IEnumerable<ClientSmallLookup>> GetAllClientSmallAsync(string accessToken)
    //    {
    //        var body = await this.GetAllAsync("GetAllClientsSmallAsync", accessToken);
    //        return JsonConvert.DeserializeObject<IEnumerable<ClientSmallLookup>>(body);
    //    }
    //    #endregion

    //    #region Employee
    //    public List<EmployeeLookup> GetAllEmployee(string accessToken)
    //    {
    //        List<EmployeeLookup> allEmployee;

    //        if (_memoryCache.TryGetValue(cacheKeyEmployee, out allEmployee))
    //        {
    //            return allEmployee;
    //        }

    //        var body = this.GetAll("GetAllEmployee", accessToken);
    //        allEmployee = JsonConvert.DeserializeObject<List<EmployeeLookup>>(body);
    //        _memoryCache.Set(cacheKeyEmployee, allEmployee, TimeSpan.FromHours(6));
    //        return allEmployee;
    //    }

    //    public async Task<IEnumerable<EmployeeLookup>> GetAllEmployeeAsync(string accessToken)
    //    {
    //        List<EmployeeLookup> allEmployee;

    //        if (_memoryCache.TryGetValue(cacheKeyEmployee, out allEmployee))
    //        {
    //            return allEmployee;
    //        }

    //        var body = await this.GetAllAsync("GetAllEmployeeAsync", accessToken);
    //        allEmployee = JsonConvert.DeserializeObject<List<EmployeeLookup>>(body);
    //        _memoryCache.Set(cacheKeyEmployee, allEmployee, TimeSpan.FromHours(6));
    //        return allEmployee;
    //    }

    //    public List<EmployeeLookup> GetAllEmployeeCanSchedule(string accessToken)
    //    {
    //        List<EmployeeLookup> allEmployee;

    //        if (_memoryCache.TryGetValue(cacheKeyEmployeeCanSchedule, out allEmployee))
    //        {
    //            return allEmployee;
    //        }

    //        var body = this.GetAll("GetAllEmployeeCanSchedule", accessToken);
    //        allEmployee = JsonConvert.DeserializeObject<List<EmployeeLookup>>(body);
    //        _memoryCache.Set(cacheKeyEmployeeCanSchedule, allEmployee, TimeSpan.FromHours(6));
    //        return allEmployee;
    //    }

    //    public async Task<IEnumerable<EmployeeLookup>> GetAllEmployeeCanScheduleAsync(string accessToken)
    //    {
    //        List<EmployeeLookup> allEmployee;

    //        if (_memoryCache.TryGetValue(cacheKeyEmployeeCanSchedule, out allEmployee))
    //        {
    //            return allEmployee;
    //        }

    //        var body = await this.GetAllAsync("GetAllEmployeeCanScheduleAsync", accessToken);
    //        allEmployee = JsonConvert.DeserializeObject<List<EmployeeLookup>>(body);
    //        _memoryCache.Set(cacheKeyEmployeeCanSchedule, allEmployee, TimeSpan.FromHours(6));
    //        return allEmployee;
    //    }
    //    #endregion

    //    #region Profession
    //    public List<BaseGuidLookup> GetAllProfession(string accessToken)
    //    {
    //        List<BaseGuidLookup> allProfession;

    //        if (_memoryCache.TryGetValue(cacheKeyProfession, out allProfession))
    //        {
    //            return allProfession;
    //        }

    //        var body = this.GetAll("GetAllProfession", accessToken);
    //        allProfession = JsonConvert.DeserializeObject<List<BaseGuidLookup>>(body);
    //        _memoryCache.Set(cacheKeyProfession, allProfession, TimeSpan.FromHours(6));
    //        return allProfession;
    //    }

    //    public async Task<IEnumerable<BaseGuidLookup>> GetAllProfessionAsync(string accessToken)
    //    {
    //        List<BaseGuidLookup> allProfession;

    //        if (_memoryCache.TryGetValue(cacheKeyProfession, out allProfession))
    //        {
    //            return allProfession;
    //        }

    //        var body = await this.GetAllAsync("GetAllProfessionAsync", accessToken);
    //        allProfession = JsonConvert.DeserializeObject<List<BaseGuidLookup>>(body);
    //        _memoryCache.Set(cacheKeyProfession, allProfession, TimeSpan.FromHours(6));
    //        return allProfession;
    //    }
    //    #endregion

    //    #region WarehouseType

    //    public IEnumerable<BaseIntLookup> GetAllWarehouseType(string accessToken)
    //    {
    //        List<BaseIntLookup> allWarehouseType;

    //        if (_memoryCache.TryGetValue(cacheKeyWarehouseType, out allWarehouseType))
    //        {
    //            return allWarehouseType;
    //        }

    //        var body = this.GetAll("GetAllWarehouseType", accessToken);
    //        allWarehouseType = JsonConvert.DeserializeObject<List<BaseIntLookup>>(body);
    //        _memoryCache.Set(cacheKeyWarehouseType, allWarehouseType, TimeSpan.FromHours(1));
    //        return allWarehouseType;
    //    }


    //    public async Task<IEnumerable<BaseIntLookup>> GetAllWarehouseTypeAsync(string accessToken)
    //    {
    //        List<BaseIntLookup> allWarehouseType;

    //        if (_memoryCache.TryGetValue(cacheKeyWarehouseCode, out allWarehouseType))
    //        {
    //            return allWarehouseType;
    //        }

    //        var body = await this.GetAllAsync("GetAllWarehouseTypeAsync", accessToken);
    //        allWarehouseType = JsonConvert.DeserializeObject<List<BaseIntLookup>>(body);
    //        _memoryCache.Set(cacheKeyWarehouseCode, allWarehouseType, TimeSpan.FromHours(1));
    //        return allWarehouseType;
    //    }

    //    #endregion

    //    #region WarehouseCode

    //    public IEnumerable<BaseGuidLookup> GetAllWarehouseCode(string accessToken)
    //    {
    //        List<BaseGuidLookup> allWarehouseCode;

    //        if (_memoryCache.TryGetValue(cacheKeyWarehouseCode, out allWarehouseCode))
    //        {
    //            return allWarehouseCode;
    //        }

    //        var body = this.GetAll("GetAllWarehouseCode", accessToken);
    //        allWarehouseCode = JsonConvert.DeserializeObject<List<BaseGuidLookup>>(body);
    //        _memoryCache.Set(cacheKeyWarehouseCode, allWarehouseCode, TimeSpan.FromHours(1));
    //        return allWarehouseCode;
    //    }

    //    public IEnumerable<BaseGuidLookup> GetAllWarehouseCode(WarehouseType warehouseType, string accessToken)
    //    {
    //        var body = this.GetAll("GetAllWarehouseCode/" + (int) warehouseType, accessToken);
    //        return JsonConvert.DeserializeObject<List<BaseGuidLookup>>(body);
    //    }

    //    public async Task<IEnumerable<BaseGuidLookup>> GetAllWarehouseCodeAsync(string accessToken)
    //    {
    //        List<BaseGuidLookup> allWarehouseCode;

    //        if (_memoryCache.TryGetValue(cacheKeyWarehouseCode, out allWarehouseCode))
    //        {
    //            return allWarehouseCode;
    //        }

    //        var body = await this.GetAllAsync("GetAllWarehouseCodeAsync", accessToken);
    //        allWarehouseCode = JsonConvert.DeserializeObject<List<BaseGuidLookup>>(body);
    //        _memoryCache.Set(cacheKeyWarehouseCode, allWarehouseCode, TimeSpan.FromHours(1));
    //        return allWarehouseCode;
    //    }



    //    public async Task<IEnumerable<BaseGuidLookup>> GetAllWarehouseCodeAsync(WarehouseType warehouseType, string accessToken)
    //    {
    //        var body = await this.GetAllAsync("GetAllWarehouseCodeAsync/" + (int) warehouseType, accessToken);
    //        return JsonConvert.DeserializeObject<List<BaseGuidLookup>>(body);
    //    }
    //    #endregion

    //    #region WarehouseName
    //    public IEnumerable<BaseGuidLookup> GetAllWarehouseName(string accessToken)
    //    {
    //        List<BaseGuidLookup> allWarehouseName;

    //        if (_memoryCache.TryGetValue(cacheKeyWarehouseName, out allWarehouseName))
    //        {
    //            return allWarehouseName;
    //        }

    //        var body = this.GetAll("GetAllWarehouseName", accessToken);
    //        allWarehouseName = JsonConvert.DeserializeObject<List<BaseGuidLookup>>(body);
    //        _memoryCache.Set(cacheKeyWarehouseName, allWarehouseName, TimeSpan.FromHours(6));
    //        return allWarehouseName;
    //    }

    //    public IEnumerable<BaseGuidLookup> GetAllWarehouseName(WarehouseType warehouseType, string accessToken)
    //    {
    //        var body = this.GetAll("GetAllWarehouseName/" + (int)warehouseType, accessToken);
    //        return JsonConvert.DeserializeObject<List<BaseGuidLookup>>(body);
    //    }

    //    public async Task<IEnumerable<BaseGuidLookup>> GetAllWarehouseNameAsync(string accessToken)
    //    {
    //        List<BaseGuidLookup> allWarehouseName;

    //        if (_memoryCache.TryGetValue(cacheKeyWarehouseName, out allWarehouseName))
    //        {
    //            return allWarehouseName;
    //        }

    //        var body = await this.GetAllAsync("GetAllWarehouseNameAsync", accessToken);
    //        allWarehouseName = JsonConvert.DeserializeObject<List<BaseGuidLookup>>(body);
    //        _memoryCache.Set(cacheKeyWarehouseName, allWarehouseName, TimeSpan.FromHours(6));
    //        return allWarehouseName;
    //    }

    //    public async Task<IEnumerable<BaseGuidLookup>> GetAllWarehouseNameAsync(WarehouseType warehouseType, string accessToken)
    //    {
    //        var body = await this.GetAllAsync("GetAllWarehouseNameAsync/" + (int)warehouseType, accessToken);
    //        return JsonConvert.DeserializeObject<List<BaseGuidLookup>>(body);
    //    }

    //    #endregion

    //    #region WorkPlace
    //    public List<BaseGuidLookup> GetAllWorkPlace(string accessToken)
    //    {
    //        List<BaseGuidLookup> allWorkPlace;

    //        if (_memoryCache.TryGetValue(cacheKeyWorkPlace, out allWorkPlace))
    //        {
    //            return allWorkPlace;
    //        }

    //        var body = this.GetAll("GetAllWorkPlace", accessToken);
    //        allWorkPlace = JsonConvert.DeserializeObject<List<BaseGuidLookup>>(body);
    //        _memoryCache.Set(cacheKeyWorkPlace, allWorkPlace, TimeSpan.FromHours(6));
    //        return allWorkPlace;
    //    }

    //    public async Task<IEnumerable<BaseGuidLookup>> GetAllWorkPlaceAsync(string accessToken)
    //    {
    //        List<BaseGuidLookup> allWorkPlace;

    //        if (_memoryCache.TryGetValue(cacheKeyWorkPlace, out allWorkPlace))
    //        {
    //            return allWorkPlace;
    //        }

    //        var body = await this.GetAllAsync("GetAllWorkPlaceAsync", accessToken);
    //        allWorkPlace = JsonConvert.DeserializeObject<List<BaseGuidLookup>>(body);
    //        _memoryCache.Set(cacheKeyWorkPlace, allWorkPlace, TimeSpan.FromHours(6));
    //        return allWorkPlace;
    //    }
    //    #endregion

    //    #region WorkShift
    //    public List<WorkShiftLookup> GetAllWorkShift(string accessToken)
    //    {
    //        List<WorkShiftLookup> allWorkShift;

    //        if (_memoryCache.TryGetValue(cacheKeyWorkShift, out allWorkShift))
    //        {
    //            return allWorkShift;
    //        }

    //        var body = this.GetAll("GetAllWorkShift", accessToken);
    //        allWorkShift = JsonConvert.DeserializeObject<List<WorkShiftLookup>>(body);
    //        _memoryCache.Set(cacheKeyWorkShift, allWorkShift, TimeSpan.FromHours(6));
    //        return allWorkShift;
    //    }

    //    public async Task<IEnumerable<WorkShiftLookup>> GetAllWorkShiftAsync(string accessToken)
    //    {
    //        List<WorkShiftLookup> allWorkShift;

    //        if (_memoryCache.TryGetValue(cacheKeyWorkShift, out allWorkShift))
    //        {
    //            return allWorkShift;
    //        }

    //        var body = await this.GetAllAsync("GetAllWorkShiftAsync", accessToken);
    //        allWorkShift = JsonConvert.DeserializeObject<List<WorkShiftLookup>>(body);
    //        _memoryCache.Set(cacheKeyWorkShift, allWorkShift, TimeSpan.FromHours(6));
    //        return allWorkShift;
    //    }
    //    #endregion


    //    #region Get
    //    public string GetAll(string endpoint, string accessToken)
    //    {
    //        //var _endpoint = _webHostApi + endpoint;

    //        //var response = _httpClient.SendAsync(GetRequestTemplate(HttpMethod.Get, _endpoint, accessToken)).Result;
    //        //var body = response.Content.ReadAsStringAsync().Result;

    //        //return body;
    //    }

    //    public async Task<string> GetAllAsync(string endpoint, string accessToken)
    //    {
    //        //var _endpoint = _webHostApi + endpoint ;

    //        //var response = await _httpClient.SendAsync(GetRequestTemplate(HttpMethod.Get, _endpoint, accessToken));
    //        //var body = await response.Content.ReadAsStringAsync();

    //        //return body;
    //    }


    //    public HttpRequestMessage GetRequestTemplate(HttpMethod method, string endpoint, string accessToken)
    //    {
    //        if ((accessToken == "") || (accessToken.Length == 0) || (accessToken == null))
    //        {
    //            throw new Exception("You are not authorized to view this content");
    //        }
    //        HttpRequestMessage req = new HttpRequestMessage();
    //        req.Method = method;
    //        req.RequestUri = new Uri(endpoint);
        
    //        req.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
    //        return req;
    //    }
    //    #endregion

    //    #region Dates
    //    public List<BaseIntLookup> GetAllMonth()
    //    {
    //       var month = System.Globalization.CultureInfo.CurrentCulture
    //                   .DateTimeFormat.MonthGenitiveNames;

    //        var monthsLookup = new List<BaseIntLookup>();

    //        var i = 1;
    //        foreach (var monthName in month)
    //        {
    //            if (string.IsNullOrEmpty(monthName))
    //            { continue; }

    //            var monthLookup = new BaseIntLookup()
    //            {
    //                Id = i,
    //                Value = monthName
    //            };

    //            monthsLookup.Add(monthLookup);

    //            i++;
    //        }

    //        return monthsLookup;
    //    }
    //    #endregion
    //}
}

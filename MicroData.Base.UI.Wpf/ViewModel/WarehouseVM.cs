using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Resource;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using MicroData.Common.UI.Shared.Identity;
using MicroData.Common.UI.Shared.Lookup;
using MicroData.Common.UI.Wpf.Enum;
using MicroData.Common.UI.Wpf.Interface;
using MicroData.Common.UI.Wpf.Model;
using MicroData.Common.UI.Wpf.ViewModels;

namespace MicroData.Base.UI.Wpf.ViewModels
{
    public class WarehouseVM : TableBaseEditor<WarehouseViewModel>
    {
        private IWarehouseApi _warehouseApi;
        private readonly ILookupBaseApi _lookupBaseApi;

        public WarehouseVM(IWarehouseApi warehouseApi, ILookupBaseApi lookupBaseApi) : base(warehouseApi)
        {
            _warehouseApi = warehouseApi;
            _lookupBaseApi = lookupBaseApi;

            SetCurrentLocation();
            SetWarehouseTypes();

            this.DelegateAddNewCommand();
            this.DelegateEditCommand();
            this.DelegatePreviewCommand();

            this.DelegateDeleteCommand();
        }

        #region Location
        private BaseGuidViewLookup CurrentLocation { get;set; }

        private async Task SetCurrentLocation()
        {
            var locations = await _lookupBaseApi.GetAllLocationAsync(CurrentUser.AccessToken);

            if (locations != null && locations.Count() > 0)
            {
                CurrentLocation = locations.FirstOrDefault();
            }
        }

        #endregion

        #region Warehouse Type
        private List<BaseIntViewLookup> AllWarehouseTypes { get; set; }

        private async Task SetWarehouseTypes()
        {
            var warehouseTypes = await _lookupBaseApi.GetAllWarehouseTypeAsync(CurrentUser.AccessToken);

            AllWarehouseTypes = warehouseTypes.ToList();

        }

        #endregion

        public override string ModelName => BaseStrings.Warehouse;
        public override bool ShowGroupPanel => false;
        public override bool ShowAddButton => true;
        public override bool ShowEditButton => true;
        public override bool ShowDeleteButton => true;
        public override bool ShowPreviewButton => true;
        public override bool ShowRightPanel => false;
        public override bool ReadAsync => true;

        public override IBaseEditorVM BaseEditorVM => GetBaseEditor();
        private IBaseEditorVM GetBaseEditor()
        {
            var baseEditorVM = new BaseEditorVM<WarehouseViewModel>(_warehouseApi);


            baseEditorVM.EditorType = EditorType.OldDataFormDialog;
            baseEditorVM.ModelName = this.ModelName;

            return baseEditorVM;
        }

        public override WarehouseViewModel GetNewItem()
        {
            var warehouse = new WarehouseViewModel();
            
            warehouse.Id = Guid.NewGuid();

            warehouse.LocationId = CurrentLocation.Id;

            //todo refactoring
            warehouse.TenantId = new Guid(CurrentCompany.TenantId);
            warehouse.CompanyId = new Guid(CurrentCompany.CompanyId);

            warehouse.CreatedBy = CurrentUser.UserName;
            warehouse.CreatedTime = DateTime.Now;
            warehouse.UpdatedBy = CurrentUser.UserName;
            warehouse.UpdatedTime = DateTime.Now;

            warehouse.IsNew = true;
            warehouse.IsReadOnly = false;

            return warehouse;
        }

        public override List<LookupList> ConvertToLookupList(WarehouseViewModel item)
        {
            var lookupList = new List<LookupList>();

            var location = new LookupList
            {
                Name = "WarehouseType",
                BindingField = "WarehouseTypeId",
                AllValue = AllWarehouseTypes.Select(s => new LookupOptions { Id = s.Id, Value = s.Value }).ToList(),
                MultiSelect = false
            };

            lookupList.Add(location);

            return lookupList;
        }

        public override WarehouseViewModel ConvertFromLookupList(WarehouseViewModel item, List<LookupList> lookupLists)
        {
            item.WarehouseTypeId = item.WarehouseTypeId;

            return item;
        }

    }
}

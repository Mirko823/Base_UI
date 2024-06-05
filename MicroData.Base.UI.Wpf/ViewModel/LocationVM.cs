using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Resource;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using MicroData.Common.UI.Shared.Identity;
using MicroData.Common.UI.Wpf.Enum;
using MicroData.Common.UI.Wpf.Interface;
using MicroData.Common.UI.Wpf.ViewModels;

namespace MicroData.Base.UI.Wpf.ViewModels
{
    public class LocationVM : TableBaseEditor<LocationViewModel>
    {
        private ILocationApi _LocationApi;

        public LocationVM(ILocationApi LocationApi) : base(LocationApi)
        {
            _LocationApi = LocationApi;

            this.DelegateAddNewCommand();
            this.DelegateEditCommand();
            this.DelegatePreviewCommand();

            this.DelegateDeleteCommand();
        }

        public override string ModelName => BaseStrings.Location;
        public override bool ShowGroupPanel => true;
        public override bool ShowAddButton => true;
        public override bool ShowEditButton => true;
        public override bool ShowDeleteButton => true;
        public override bool ShowPreviewButton => true;
        public override bool ShowRightPanel => false;
        public override bool ReadAsync => false;

        public override IBaseEditorVM BaseEditorVM => GetBaseEditor();
        private IBaseEditorVM GetBaseEditor()
        {
            var baseEditorVM = new BaseEditorVM<LocationViewModel>(_LocationApi);
            baseEditorVM.EditorType = EditorType.BaseDataFormDialog;
            baseEditorVM.ModelName = this.ModelName;

            return baseEditorVM;
        }

        public override LocationViewModel GetNewItem()
        {
            var location = new LocationViewModel();

            location.Id = Guid.NewGuid();

            //todo refactoring
            location.TenantId = new Guid(CurrentCompany.TenantId);
            location.CompanyId = new Guid(CurrentCompany.CompanyId);
            
            location.IsNew = true;
            location.IsReadOnly = false;

            return location;
        }

        //public override LocationModel GetEditItem()
        //{
        //    return _LocationApi.Get(this.SelectedItem.Id);
        //}

    }
}

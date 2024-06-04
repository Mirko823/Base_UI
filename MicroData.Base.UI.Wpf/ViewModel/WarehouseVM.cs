﻿using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using MicroData.Common.UI.Shared.Identity;
using MicroData.Common.UI.Wpf.Enum;
using MicroData.Common.UI.Wpf.Interface;
using MicroData.Common.UI.Wpf.ViewModels;

namespace MicroData.Base.UI.Wpf.ViewModels
{
    public class WarehouseVM : TableBaseEditor<WarehouseViewModel>
    {
        private IWarehouseApi _warehouseApi;

        public WarehouseVM(IWarehouseApi warehouseApi) : base(warehouseApi)
        {
            _warehouseApi = warehouseApi;

            this.DelegateAddNewCommand();
            this.DelegateEditCommand();
            this.DelegatePreviewCommand();

            this.DelegateDeleteCommand();
        }

        public override string ModelName => "Skladiste";
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


            baseEditorVM.EditorType = EditorType.BaseDataFormDialog;
            baseEditorVM.ModelName = this.ModelName;

            return baseEditorVM;
        }

        public override WarehouseViewModel GetNewItem()
        {
            var warehouse = new WarehouseViewModel();
            warehouse.IsNew = true;
            warehouse.IsReadOnly = false;

            //todo refactoring
            warehouse.TenantId = new Guid(CurrentCompany.TenantId);
            warehouse.CompanyId = new Guid(CurrentCompany.CompanyId);


            return warehouse;
        }

    }
}

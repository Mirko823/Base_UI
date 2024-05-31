using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using MicroData.Common.UI.Shared.Identity;
using MicroData.Common.UI.Wpf.Enum;
using MicroData.Common.UI.Wpf.Interface;
using MicroData.Common.UI.Wpf.ViewModels;

namespace MicroData.Base.UI.Wpf.ViewModels
{
    public class EmployeeVM : TableBaseEditor<EmployeeViewModel>
    {
        private IEmployeeApi _employeeApi;

        public EmployeeVM(IEmployeeApi employeeApi) : base(employeeApi)
        {
            _employeeApi = employeeApi;

            this.DelegateAddNewCommand();
            this.DelegateEditCommand();
            this.DelegatePreviewCommand();

            this.DelegateDeleteCommand();
        }

        public override string ModelName => "Zaposleni";
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
            var baseEditorVM = new BaseEditorVM<EmployeeViewModel>(_employeeApi);
            baseEditorVM.EditorType = EditorType.BaseDataFormDialog;
            baseEditorVM.ModelName = this.ModelName;

            return baseEditorVM;
        }

        public override EmployeeViewModel GetNewItem()
        {
            var employee = new EmployeeViewModel();
            employee.IsNew = true;
            employee.IsReadOnly = false;

            //todo refactoring
            employee.TenantId = new Guid(CurrentCompany.TenantId);
            employee.CompanyId = new Guid(CurrentCompany.CompanyId);
            
            employee.CreatedBy = CurrentUser.UserName;
            employee.UpdatedBy = CurrentUser.UserName;

            employee.CreatedTime = DateTime.Now;
            employee.UpdatedTime = DateTime.Now;

            return employee;
        }

        //public override EmployeeModel GetEditItem()
        //{
        //    return _employeeApi.Get(this.SelectedItem.Id);
        //}

    }
}

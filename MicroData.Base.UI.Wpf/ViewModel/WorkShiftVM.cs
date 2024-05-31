using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using MicroData.Common.UI.Wpf.Enum;
using MicroData.Common.UI.Wpf.Interface;
using MicroData.Common.UI.Wpf.ViewModels;

namespace MicroData.Base.UI.Wpf.ViewModels
{
    public class WorkShiftVM : TableBaseEditor<WorkShiftViewModel>
    {
        private IWorkShiftApi _workshiftApi;

        public WorkShiftVM(IWorkShiftApi workshiftApi) : base(workshiftApi)
        {
            _workshiftApi = workshiftApi;
            this.DelegatePreviewCommand();
        }

        public override string ModelName => "Radne smene";
        public override bool ShowGroupPanel => false;
        public override bool ShowAddButton => false;
        public override bool ShowEditButton => false;
        public override bool ShowDeleteButton => false;
        public override bool ShowPreviewButton => true;
        public override bool ShowRightPanel => false;
        public override bool ReadAsync => true;

        public override IBaseEditorVM BaseEditorVM => GetBaseEditor();
        private IBaseEditorVM GetBaseEditor()
        {
            var baseEditorVM = new BaseEditorVM<WorkShiftViewModel>(_workshiftApi);
            baseEditorVM.EditorType = EditorType.BaseDataFormDialog;
            baseEditorVM.ModelName = this.ModelName;

            return baseEditorVM;
        }

    }
}

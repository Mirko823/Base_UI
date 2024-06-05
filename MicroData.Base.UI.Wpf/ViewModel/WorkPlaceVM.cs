using MicroData.Common.UI.Wpf.Enum;
using MicroData.Common.UI.Wpf.Interface;
using MicroData.Common.UI.Wpf.ViewModels;
using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using MicroData.Base.UI.Resource;

namespace MicroData.Base.UI.Wpf.ViewModels
{
    public class WorkPlaceVM : TableBaseEditor<WorkPlaceViewModel>
    {
        private IWorkPlaceApi _workTaskApi;

        public WorkPlaceVM(IWorkPlaceApi workTaskApi) : base(workTaskApi)
        {
            _workTaskApi = workTaskApi;

            this.DelegateAddNewCommand();
            this.DelegateEditCommand();
            this.DelegatePreviewCommand();

            this.DelegateDeleteCommand();
        }

        public override string ModelName => BaseStrings.WorkPlace;
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
            var baseEditorVM = new BaseEditorVM<WorkPlaceViewModel>(_workTaskApi);
            baseEditorVM.EditorType = EditorType.BaseDataFormDialog;
            baseEditorVM.ModelName = this.ModelName;

            return baseEditorVM;
        }

        public override WorkPlaceViewModel GetNewItem()
        {
            var WorkTask = new WorkPlaceViewModel();
            WorkTask.IsNew = true;
            WorkTask.IsReadOnly = false;

            return WorkTask;
        }

    }
}

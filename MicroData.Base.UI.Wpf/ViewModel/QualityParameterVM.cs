using MicroData.Base.UI.Resource;
using MicroData.Base.UI.Shared.Api;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using MicroData.Common.UI.Shared.Identity;
using MicroData.Common.UI.Wpf.Enum;
using MicroData.Common.UI.Wpf.Interface;
using MicroData.Common.UI.Wpf.ViewModels;

namespace MicroData.Base.UI.Wpf.ViewModels
{
    public class QualityParameterVM : TableBaseEditor<QualityParameterViewModel>
    {
        private IQualityParameterApi _qualityParameterApi;

        public QualityParameterVM(IQualityParameterApi qualityParameterApi) : base(qualityParameterApi)
        {
            _qualityParameterApi = qualityParameterApi;

            this.DelegateAddNewCommand();
            this.DelegateEditCommand();
            this.DelegatePreviewCommand();

            this.DelegateDeleteCommand();
        }

        public override string ModelName => BaseStrings.QualityParameter;
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
            var baseEditorVM = new BaseEditorVM<QualityParameterViewModel>(_qualityParameterApi);
            baseEditorVM.EditorType = EditorType.BaseDataFormDialog;
            baseEditorVM.ModelName = this.ModelName;

            return baseEditorVM;
        }

        public override QualityParameterViewModel GetNewItem()
        {
            var qualityParameter = new QualityParameterViewModel();
            qualityParameter.IsNew = true;
            qualityParameter.IsReadOnly = false;


            return qualityParameter;
        }

    }
}

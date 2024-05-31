using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using MicroData.Common.UI.Wpf.Enum;
using MicroData.Common.UI.Wpf.Interface;
using MicroData.Common.UI.Wpf.ViewModels;
using System;

namespace MicroData.Base.UI.Wpf.ViewModels
{
    public class ClientVM : TableBaseEditor<ClientViewModel>
    {
        private IClientApi _clientApi;

        public ClientVM(IClientApi clientApi) : base(clientApi)
        {
            _clientApi = clientApi;

            this.DelegateAddNewCommand();
            this.DelegateEditCommand();
            this.DelegatePreviewCommand();

            this.DelegateDeleteCommand();
        }

        public override string ModelName => "Klijenti";
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
            var baseEditorVM = new BaseEditorVM<ClientViewModel>(_clientApi);
            baseEditorVM.EditorType = EditorType.BaseEditorDialog;
            baseEditorVM.DataFormTeplate = new Uri(@"/MicroData.Base.UI.Wpf;component/ViewsTemplete/ClientTemplate.xaml", UriKind.RelativeOrAbsolute);
            baseEditorVM.ModelName = this.ModelName;

            return baseEditorVM;
        }

    }
}

using MicroData.Base.Data.Entity;
using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using MicroData.Common.Domain.Interface;
using MicroData.Common.UI.Shared.Identity;
using MicroData.Common.UI.Wpf.Enum;
using MicroData.Common.UI.Wpf.Interface;
using MicroData.Common.UI.Wpf.Model;
using MicroData.Common.UI.Wpf.ViewModels;

namespace MicroData.Base.UI.Wpf.ViewModels
{
    public class ShipperVM : TableBaseEditor<ShipperViewModel>
    {
        private readonly IShipperApi _ShipperApi;
        private readonly ILookupBaseApi _lookupApi;
        private IBaseEditorVM baseEditorVM;

        public ShipperVM(IShipperApi ShipperApi, ILookupBaseApi lookupApi) : base(ShipperApi)
        {
            _ShipperApi = ShipperApi;
            _lookupApi = lookupApi;

            this.DelegateAddNewCommand();
            this.DelegateEditCommand();
            this.DelegatePreviewCommand();

        }

        public override string ModelName => "Prevoznici";
        public override bool ShowGroupPanel => true;
        public override bool ShowRightPanel => false;
        public override bool ReadAsync => false;

        public override IBaseEditorVM BaseEditorVM => GetBaseEditor();

        private IBaseEditorVM GetBaseEditor()
        {
            baseEditorVM = new BaseEditorVM<ShipperViewModel>(_ShipperApi);
            baseEditorVM.EditorType = EditorType.BaseEditorDialog;
            baseEditorVM.DataFormTeplate = new Uri(@"/MicroData.Base.UI.Wpf;component/ViewsTemplete/ShipperTemplate.xaml", UriKind.RelativeOrAbsolute);
            baseEditorVM.ModelName = this.ModelName;

            return baseEditorVM;
        }

        public override ShipperViewModel GetNewItem()
        {
            var newItem = new ShipperViewModel();
            newItem.IsReadOnly = false;
            newItem.CanEdit = true;
            newItem.State = "RS";

            //todo refactoring
            newItem.RegistryNumber = string.Empty;
            newItem.TaxNumber = string.Empty;

            newItem.TenantId = new Guid(CurrentCompany.TenantId);
            newItem.CompanyId = new Guid(CurrentCompany.CompanyId);

            newItem.CreatedBy = CurrentUser.UserName;
            newItem.UpdatedBy = CurrentUser.UserName;

            newItem.CreatedTime = DateTime.Now;
            newItem.UpdatedTime = DateTime.Now;
            //newItem.AllComapnies = _lookupApi.GetAllRegisteredCompanyOnSef(CurrentUser.AccessToken);


            return newItem;
        }

        public override ShipperViewModel GetEditItem()
        {
            var item = base.GetEditItem();
            item.IsReadOnly = false;
            item.CanEdit = true;

            //item.AllComapnies = _lookupApi.GetAllRegisteredCompanyOnSef(CurrentUser.AccessToken);

            return item;
        }


        public override ReportProperties GetReportProperties()
        {
            var reportParameters = new List<ReportParameter>
                    {
                    new ReportParameter
                    {
                        Name = "docId",
                        Value = ((IBaseModel)this.SelectedItem).Id.ToString()
                    }
                };

            var reportProperties = new ReportProperties
            {
                ReportName = "Offer.trdp",
                ReportParameters = reportParameters
            };

            return reportProperties;
        }
    }
}
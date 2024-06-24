using MicroData.Base.Domain.Lookup;
using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Resource;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using MicroData.Common.Domain.Interface;
using MicroData.Common.Domain.Lookup;
using MicroData.Common.UI.Shared.Identity;
using MicroData.Common.UI.Wpf.Enum;
using MicroData.Common.UI.Wpf.Helpers;
using MicroData.Common.UI.Wpf.Interface;
using MicroData.Common.UI.Wpf.Model;
using MicroData.Common.UI.Wpf.ViewModels;
using Telerik.Windows.Controls;

namespace MicroData.Base.UI.Wpf.ViewModels
{
    public class ServiceCatalogVM : TableBaseEditor<ServiceCatalogViewModel>
    {
        private readonly IServiceCatalogApi _serviceCatalogApi;
        private readonly ILookupBaseApi _lookupBaseApi;
        private IBaseEditorVM baseEditorVM;

        public ServiceCatalogVM(IServiceCatalogApi serviceCatalogApi, ILookupBaseApi lookupBaseApi) : base(serviceCatalogApi)
        {
            _serviceCatalogApi = serviceCatalogApi;

            this.DelegateAddNewCommand();
            this.DelegateEditCommand();
            this.DelegatePreviewCommand();

            this.DelegateImportCommand();
            this.DelegateExportCommand();

            _lookupBaseApi = lookupBaseApi;
            _lookupBaseApi.GetAllTaxesAsync(CurrentUser.AccessToken);
            _lookupBaseApi.GetAllUnitAsync(CurrentUser.AccessToken);
        }

        public override string ModelName => BaseStrings.Service;
        public override bool ShowGroupPanel => true;
        public override bool ShowRightPanel => true;
        public override bool ShowImportButton => true;
        public override bool ShowExportButton => true;
        public override bool ReadAsync => false;

        public override IBaseEditorVM BaseEditorVM => GetBaseEditor();

        private IBaseEditorVM GetBaseEditor()
        {
            baseEditorVM =  new BaseEditorVM<ServiceCatalogViewModel>(_serviceCatalogApi);
            baseEditorVM.EditorType = EditorType.BaseEditorDialog;
            baseEditorVM.DataFormTeplate = new Uri(@"/MicroData.Base.UI.Wpf;component/ViewsTemplete/CatalogTemplate.xaml", UriKind.RelativeOrAbsolute);
            baseEditorVM.ModelName = this.ModelName;

            return baseEditorVM;
        }


        public override ServiceCatalogViewModel GetNewItem()
        {
            var newItem = new ServiceCatalogViewModel();
            
            newItem.Id = Guid.NewGuid();
            newItem.TenantId = new Guid(CurrentCompany.TenantId);
            newItem.CompanyId = new Guid(CurrentCompany.CompanyId);

            newItem.IsReadOnly = false;
            newItem.AllTaxes = _lookupBaseApi.GetAllTaxes(CurrentUser.AccessToken);
            newItem.AllUnits = _lookupBaseApi.GetAllUnit(CurrentUser.AccessToken);

            var selectedItem = this.SelectedItem;

            if (selectedItem != null)
            {
                newItem.UnitId = this.SelectedItem.UnitId;
                newItem.TaxId = this.SelectedItem.TaxId;
            }
            else
            {
                var defaultUnit = newItem.AllUnits.FirstOrDefault(f => f.Value == "kom");
                if (defaultUnit != null)
                    newItem.UnitId =Convert.ToInt32(defaultUnit.Id);

                if (CurrentCompany.InVat)
                {
                    var defaultTax = newItem.AllTaxes.FirstOrDefault(f => f.Rate == 20);
                    if (defaultTax != null)
                        newItem.TaxId = Convert.ToInt32(defaultTax.Id);
                }
                else
                {
                    var defaultTax = newItem.AllTaxes.FirstOrDefault(f => f.Rate == 0);
                    if (defaultTax != null)
                        newItem.TaxId = Convert.ToInt32(defaultTax.Id);
                }
            }

            return newItem;
        }


        public override ServiceCatalogViewModel GetEditItem()
        {
            var item = _serviceCatalogApi.Get(this.SelectedItem.Id, CurrentUser.AccessToken);
            item.IsReadOnly = false;
            item.AllTaxes = _lookupBaseApi.GetAllTaxes(CurrentUser.AccessToken);
            item.AllUnits = _lookupBaseApi.GetAllUnit(CurrentUser.AccessToken);

            return item;
        }

        public void DelegateImportCommand()
        {
            this.ImportCommand = new DelegateCommand(
            (o) =>
            {
                RadOpenFileDialog openFileDialog = new RadOpenFileDialog();
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = false;
                openFileDialog.Filter =
                            "|Text Files|*.csv";  //+*.xlsx;*.json;
                                                  //"|All Files|*.*";

                openFileDialog.ShowDialog();

                if (openFileDialog.DialogResult == true)
                {

                    if (openFileDialog.DialogResult == true)
                    {
                        ShowBusy(true);

                        //AllUnits = _lookupBaseApi.GetAllUnit(CurrentUser.AccessToken);
                        //AllTaxes = _lookupBaseApi.GetAllTaxes(CurrentUser.AccessToken);

                        var importItems = CsvHelper.CatalogImportFromCsv(openFileDialog.FileName);

                        var productCatalog = importItems
                           .Select(s => new ServiceCatalogViewModel()
                           {
                               //Id = Guid.NewGuid(),
                               TenantId = new Guid(CurrentCompany.TenantId),
                               ExportId = s.Id,
                               BarCode = s.Barcode,
                               Code = s.Code,
                               Name = s.Name,
                               UnitId = GetUnitId(s.Unit),
                               TaxId = GetTaxId(s.TaxRate),
                               Price = s.Price
                           });

                        HideBusy();

                        List<ServiceCatalogViewModel> allProdactCatalogsFromDb = this.GetItems.ToList();

                        foreach (var product in productCatalog)
                        {
                            var prodactFromDb = allProdactCatalogsFromDb.FirstOrDefault(f => f.Code == product.Code || f.BarCode == product.BarCode);

                            var unit = AllUnits.FirstOrDefault(f => f.Id == product.UnitId);
                            if (unit == null)
                                continue;

                            product.Unit = unit.Value;

                            var tax = AllTaxes.FirstOrDefault(f => f.Id == product.TaxId);
                            if (tax == null)
                                continue;

                            product.TaxLabel = tax.Value;

                            if (prodactFromDb != null)
                            {
                                _serviceCatalogApi.EditExisting(product, CurrentUser.AccessToken);
                            }
                            else
                            {
                                _serviceCatalogApi.CreateNew(product, CurrentUser.AccessToken);
                            }
                           
                        }
                        this.RefreshItems();
                    }

                }
            });
        }

        private List<BaseIntLookup> AllUnits;
        private List<TaxLookup> AllTaxes;

        private int GetUnitId(string unitLabel)
        {
            var unit = AllUnits.FirstOrDefault(f => f.Value == unitLabel);

            if (unit == null)
                return 0;

            return (int)unit.Id;
        }

        private int? GetTaxId(decimal taxRate)
        {
            var tax = AllTaxes.FirstOrDefault(f => f.Rate == taxRate);

            if (tax == null)
                return null;

            return (int)tax.Id;
        }

        public void DelegateExportCommand()
        {
            this.ExportCommand = new DelegateCommand(
            (o) =>
            {
                //var printPreview = new ReportViewerWindow();
                //printPreview.PrintReport(this.GetReportProperties());
            });
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
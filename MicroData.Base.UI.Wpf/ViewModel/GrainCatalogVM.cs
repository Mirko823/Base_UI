using MicroData.Base.UI.Resource;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.Lookup;
using MicroData.Base.UI.Shared.ViewModel;
using MicroData.Common.Domain.Lookup;
using MicroData.Common.UI.Shared.Identity;
using MicroData.Common.UI.Wpf.Enum;
using MicroData.Common.UI.Wpf.Helpers;
using MicroData.Common.UI.Wpf.Interface;
using MicroData.Common.UI.Wpf.ViewModels;
using Telerik.Windows.Controls;

namespace MicroData.Base.UI.Wpf.ViewModels
{
    public class GrainCatalogVM : TableBaseEditor<GrainCatalogViewModel>
    {
        private readonly IGrainCatalogApi _grainCatalogApi;
        private readonly ILookupBaseApi _lookupBaseApi;
        private IBaseEditorVM baseEditorVM;
        public GrainCatalogVM(IGrainCatalogApi grainCatalogApi, ILookupBaseApi lookupBaseApi) : base(grainCatalogApi)
        {
            _grainCatalogApi = grainCatalogApi;
            _lookupBaseApi = lookupBaseApi;

            this.DelegateAddNewCommand();
            this.DelegateEditCommand();
            this.DelegatePreviewCommand();

            this.DelegateImportCommand();
            this.DelegateExportCommand();


            _lookupBaseApi.GetAllTaxesAsync(CurrentUser.AccessToken);
            _lookupBaseApi.GetAllUnitAsync(CurrentUser.AccessToken);
        }

        public override string ModelName => BaseStrings.Grain;
        public override bool ShowGroupPanel => true;

        public override bool ShowAddButton => true;
        public override bool ShowEditButton => true;
        public override bool ShowDeleteButton => true;

        public override bool ShowRightPanel => false;
        public override bool ShowImportButton => true;
        public override bool ShowExportButton => true;

        public override bool ReadAsync => false;

        public override IBaseEditorVM BaseEditorVM => GetBaseEditor();

        private IBaseEditorVM GetBaseEditor()
        {
            baseEditorVM = new BaseEditorVM<GrainCatalogViewModel>(_grainCatalogApi);
            baseEditorVM.EditorType = EditorType.BaseEditorDialog;
            baseEditorVM.DataFormTeplate = new Uri(@"/MicroData.Base.UI.Wpf;component/ViewsTemplete/CatalogTemplate.xaml", UriKind.RelativeOrAbsolute);
            baseEditorVM.ModelName = this.ModelName;

            return baseEditorVM;
        }


        public override GrainCatalogViewModel GetNewItem()
        {
            var newItem = new GrainCatalogViewModel();
            
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
                    newItem.UnitId = Convert.ToInt32(defaultUnit.Id);

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

            newItem.CreatedBy = CurrentUser.UserName;
            newItem.UpdatedBy = CurrentUser.UserName;

            newItem.CreatedTime = DateTime.Now;
            newItem.UpdatedTime = DateTime.Now; 

            return newItem;
        }

        public override GrainCatalogViewModel GetEditItem()
        {
            var item = _grainCatalogApi.Get(this.SelectedItem.Id, CurrentUser.AccessToken);
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
                    ShowBusy(true);

                    //AllUnits = _lookupBaseApi.GetAllUnit(CurrentUser.AccessToken);
                    //AllTaxes = _lookupBaseApi.GetAllTaxes(CurrentUser.AccessToken);

                    var importItems = CsvHelper.CatalogImportFromCsv(openFileDialog.FileName);

                    var GrainCatalog = importItems
                       .Select(s => new GrainCatalogViewModel()
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

                    List<GrainCatalogViewModel> allProdactCatalogsFromDb = this.GetItems.ToList();

                    foreach (var Grain in GrainCatalog)
                    {
                        var prodactFromDb = allProdactCatalogsFromDb.FirstOrDefault(f=>f.Code == Grain.Code || f.BarCode == Grain.BarCode);

                        var unit = AllUnits.FirstOrDefault(f => f.Id == Grain.UnitId);
                        if (unit == null)
                            continue;

                        Grain.Unit = unit.Value;

                        var tax = AllTaxes.FirstOrDefault(f => f.Id == Grain.TaxId);
                        if (tax == null)
                            continue;

                        Grain.TaxLabel = tax.Value;

                        if (prodactFromDb != null)
                        {
                            _grainCatalogApi.EditExisting(Grain,CurrentUser.AccessToken);
                        }
                        else
                        {
                            _grainCatalogApi.CreateNew(Grain, CurrentUser.AccessToken);
                        }
                    }

                    this.RefreshItems();

                }
            });
        }

        private List<BaseIntLookup> AllUnits;
        private List<TaxViewLookup> AllTaxes;

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


    }
}
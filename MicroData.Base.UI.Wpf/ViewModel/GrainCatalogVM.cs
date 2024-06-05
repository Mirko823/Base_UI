using MicroData.Base.Domain.Lookup;
using MicroData.Base.UI.Resource;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using MicroData.Base.UI.Wpf.Controls;
using MicroData.Common.Domain.Lookup;
using MicroData.Common.UI.Shared.Identity;
using MicroData.Common.UI.Wpf.Dialog.EditorItemsDialog;
using MicroData.Common.UI.Wpf.Dialog.Interface;
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
        private IEditorItemsDialogFactory dialogItemsFactory;
        private Uri dataFormTemplate;
        public GrainCatalogVM(IGrainCatalogApi GrainCatalogApi, ILookupBaseApi lookupBaseApi) : base(GrainCatalogApi)
        {
            _grainCatalogApi = GrainCatalogApi;
            _lookupBaseApi = lookupBaseApi;

            this.DelegateGrainAddNewCommand();
            this.DelegateGrainEditCommand();
            this.DelegateGrainPreviewCommand();

            this.DelegateImportCommand();
            this.DelegateExportCommand();


            _lookupBaseApi.GetAllTaxesAsync(CurrentUser.AccessToken);
            _lookupBaseApi.GetAllUnitAsync(CurrentUser.AccessToken);
            _lookupBaseApi.GetAllQualityParameterAsync(CurrentUser.AccessToken);

            CreateDialogFactory();
        }

        public override string ModelName => BaseStrings.Grain;
        public override bool ShowGroupPanel => true;

        public override bool ShowAddButton => true;
        public override bool ShowEditButton => true;
        public override bool ShowDeleteButton => true;

        public override bool ShowRightPanel => true;
        public override bool ShowImportButton => true;
        public override bool ShowExportButton => true;

        public override bool ReadAsync => false;

        public override IBaseEditorVM BaseEditorVM => null;

        private IBaseEditorVM GetBaseEditor()
        {
            baseEditorVM = new BaseEditorVM<GrainCatalogViewModel>(_grainCatalogApi);
            baseEditorVM.EditorType = EditorType.BaseEditorDialog;
            baseEditorVM.DataFormTeplate = new Uri(@"/MicroData.Base.UI.Wpf;component/ViewsTemplete/CatalogTemplate.xaml", UriKind.RelativeOrAbsolute);
            baseEditorVM.ModelName = this.ModelName;

            return baseEditorVM;
        }

        private void CreateDialogFactory()
        {
            dialogItemsFactory = new EditorItemsDialogFactory();
            dialogItemsFactory.TargetModelName = ModelName;

            dataFormTemplate = new Uri(@"/MicroData.Base.UI.Wpf;component/ViewsTemplete/CatalogTemplate.xaml", UriKind.RelativeOrAbsolute);

            dialogItemsFactory.DataFormTeplate = dataFormTemplate;
        }

        private void CreateDialogFactoryItems(GrainCatalogViewModel item)
        {
            dialogItemsFactory.TargetItemName = item.Name;

            var editorItems = new List<EditorItem>{
                        new EditorItem(){
                        TabHeader = BaseStrings.QualityParameter,
                        CustomControl = new GridCatalogQualitetyParametersItems(item)
                        }
                    };

            dialogItemsFactory.EditorItems = editorItems;
        }

        public void DelegateGrainAddNewCommand()
        {
            this.AddNewRecordCommand = new DelegateCommand(
                (o) =>
                {

                    ShowBusy(false);
                    var newItem = this.GetNewItem();
                    CreateDialogFactoryItems(newItem);
                    HideBusy();

                    dialogItemsFactory.ShowNewDialog(newItem);

                    if (dialogItemsFactory.SaveChanges)
                    {
                        var currentItem = (GrainCatalogViewModel)dialogItemsFactory.CurrentItem;
                        if (newItem != null)
                        {
                            this.ShowBusy(false);

                            var itemFromDb = _grainCatalogApi.CreateNew(currentItem,CurrentUser.AccessToken);

                            this.RefreshItems();
                            this.HideBusy();
                        }

                    }
                });
        }
        public override GrainCatalogViewModel GetNewItem()
        {
            var newItem = new GrainCatalogViewModel();
            
            newItem.Id = Guid.NewGuid();
            newItem.TenantId = new Guid(CurrentCompany.TenantId);
            newItem.CompanyId = new Guid(CurrentCompany.CompanyId);

            newItem.IsReadOnly = false;

            newItem.CatalogQualityParameters = new List<CatalogQualityParameterViewModel>();

            newItem.AllTaxes = _lookupBaseApi.GetAllTaxes(CurrentUser.AccessToken);
            newItem.AllUnits = _lookupBaseApi.GetAllUnit(CurrentUser.AccessToken);
            newItem.AllQualityParameters = _lookupBaseApi.GetAllQualityParameter(CurrentUser.AccessToken).ToList();

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

        public void DelegateGrainEditCommand()
        {
            this.EditRecordCommand = new DelegateCommand(
                (o) =>
                {

                    ShowBusy(false);
                    var item = _grainCatalogApi.Get(this.SelectedItem.Id, CurrentUser.AccessToken);
                    item.CatalogQualityParameters = _grainCatalogApi.GetQualityParameterByCatalogId(this.SelectedItem.Id.ToString(), CurrentUser.AccessToken).ToList();

                    item.AllTaxes = _lookupBaseApi.GetAllTaxes(CurrentUser.AccessToken);
                    item.AllUnits = _lookupBaseApi.GetAllUnit(CurrentUser.AccessToken);
                    item.AllQualityParameters = _lookupBaseApi.GetAllQualityParameter(CurrentUser.AccessToken).ToList();

                    CreateDialogFactoryItems(item);
                    HideBusy();

                    dialogItemsFactory.ShowEditDialog(item);


                    if (dialogItemsFactory.SaveChanges)
                    {
                        this.ShowBusy(false);
                        var currentItem = (GrainCatalogViewModel)dialogItemsFactory.CurrentItem;
                        if (currentItem != null)
                        {
                            //ClearLookup(ref currentItem);
                            var itemFromDb = _grainCatalogApi.EditExisting(currentItem, CurrentUser.AccessToken);

                            var found = this.GetItems.FirstOrDefault(x => x.Id == itemFromDb.Id);
                            int i = GetItems.IndexOf(found);
                            this.GetItems[i] = itemFromDb;
                        }
                        this.HideBusy();
                    }

                },
                (o) => this.SelectedItem != null);
        }


        public void DelegateGrainPreviewCommand()
        {
            this.PreviewRecordCommand = new DelegateCommand(
                (o) =>
                {

                    ShowBusy(false);
                    var item = _grainCatalogApi.GetPreview(this.SelectedItem.Id, CurrentUser.AccessToken);
                    item.CatalogQualityParameters = _grainCatalogApi.GetQualityParameterByCatalogId(this.SelectedItem.Id.ToString(), CurrentUser.AccessToken).ToList();

                    CreateDialogFactoryItems(item);
                    this.HideBusy();

                    dialogItemsFactory.ShowPreviewDialog(item);


                },
                (o) => this.SelectedItem != null);
        }

        public override GrainCatalogViewModel GetEditItem()
        {
            var item = _grainCatalogApi.Get(this.SelectedItem.Id, CurrentUser.AccessToken);
            item.IsReadOnly = false;
            
          
            
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

    }
}
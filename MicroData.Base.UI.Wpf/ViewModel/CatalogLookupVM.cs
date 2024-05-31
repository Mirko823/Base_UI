using MicroData.Base.Domain.Model;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Common.UI.Wpf.Enum;
using MicroData.Common.UI.Wpf.Interface;
using MicroData.Common.UI.Wpf.ViewModels;
using MicroData.Base.Domain.Lookup;

namespace MicroData.Base.UI.Wpf.ViewModels
{
    //public class CatalogLookupVM : TableBaseEditor<CatalogSmallLookup>
    //{
    //    private ICatalogLookupApi _catalogLookupApi;

    //    public CatalogLookupVM(ICatalogLookupApi catalogLookupApi) : base(catalogLookupApi)
    //    {
    //        _catalogLookupApi = catalogLookupApi;
    //        this.DelegatePreviewCommand();
    //    }

    //    public override string ModelName => "Sirovine";
    //    public override bool ShowGroupPanel => false;
    //    public override bool ShowAddButton => false;
    //    public override bool ShowEditButton => false;
    //    public override bool ShowDeleteButton => false;
    //    public override bool ShowPreviewButton => true;
    //    public override bool ShowRightPanel => false;
    //    public override bool ReadAsync => true;

    //    public override IBaseEditorVM BaseEditorVM => GetBaseEditor();
    //    private IBaseEditorVM GetBaseEditor()
    //    {
    //        var baseEditorVM = new BaseEditorVM<CatalogSmallLookup>(_catalogLookupApi);
    //        baseEditorVM.EditorType = EditorType.BaseDataFormDialog;
    //        baseEditorVM.ModelName = this.ModelName;

    //        return baseEditorVM;
    //    }

    //}
}

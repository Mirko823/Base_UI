using MicroData.Base.UI.Shared.ViewModel;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace MicroData.Base.UI.Wpf.Controls;

public partial class GridCatalogQualitetyParametersItems : UserControl
{
    private GrainCatalogViewModel CurrentItem { get; set; }
    public GridCatalogQualitetyParametersItems(GrainCatalogViewModel grainCatalog)
    {
        System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(RadGridViewCommands).TypeHandle);

        InitializeComponent();

        CurrentItem = grainCatalog;
        gridViewGrain.ItemsSource = grainCatalog.CatalogQualityParameters;

    }

    private void gridViewProduct_BeginningEdit(object sender, GridViewBeginningEditRoutedEventArgs e)
    {
        var item = (CatalogQualityParameterViewModel) e.Row.Item;

        if (item.GrainCatalog == null)
        {
            if (item.Description == null)
                item.Description = string.Empty;

            if (item.Id == Guid.Empty)
            {
                item.Id = Guid.NewGuid();
            }

            item.GrainCatalog = CurrentItem;
            item.AllQualityParameters = CurrentItem.AllQualityParameters;
        }
    }
}

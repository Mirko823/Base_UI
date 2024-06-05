using MicroData.Base.UI.Resource;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using MicroData.Common.UI.Wpf.ViewModels;

namespace MicroData.Base.UI.Wpf.ViewModels
{
    public class TaxVM : TableModelBase<TaxViewModel>
    {
        private ITaxApi _taxApi;

        public TaxVM(ITaxApi taxApi) : base(taxApi)
        {
            _taxApi = taxApi;


        }

        public override string ModelName => BaseStrings.Tax;
        public override bool ShowGroupPanel => false;
        public override bool ShowRightPanel => false;
        public override bool ReadAsync => true;

    }
}

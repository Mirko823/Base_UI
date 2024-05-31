using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using MicroData.Common.UI.Wpf.ViewModels;

namespace MicroData.Base.UI.Wpf.ViewModels
{
    public class CurrencyVM : TableModelBase<CurrencyViewModel>
    {
        private ICurrencyApi _currencyApi;

        public CurrencyVM(ICurrencyApi currencyApi) : base(currencyApi)
        {
            _currencyApi = currencyApi;

        }

        public override string ModelName => "Jedinica Mere";
        public override bool ShowGroupPanel => false;
        public override bool ShowRightPanel => false;
        public override bool ReadAsync => true;

    }
}

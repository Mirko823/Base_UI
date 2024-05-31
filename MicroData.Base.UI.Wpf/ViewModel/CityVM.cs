using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using MicroData.Common.UI.Wpf.ViewModels;

namespace MicroData.Base.UI.Wpf.ViewModels
{
    public class CityVM : TableModelBase<CityViewModel>
    {
        private ICityApi _cityApi;

        public CityVM(ICityApi cityApi) : base(cityApi)
        {
            _cityApi = cityApi;
        }

        public override string ModelName => "Mesto";
        public override bool ShowGroupPanel => true;
        public override bool ShowRightPanel => false;
        public override bool ReadAsync => true;

    }
}

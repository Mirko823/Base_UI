using MicroData.Base.UI.Resource;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using MicroData.Common.UI.Wpf.ViewModels;

namespace MicroData.Base.UI.Wpf.ViewModels
{
    public class UnitVM : TableModelBase<UnitViewModel>
    {
        private IUnitApi _unitApi;

        public UnitVM(IUnitApi unitApi) : base(unitApi)
        {
            _unitApi = unitApi;
        }

        public override string ModelName => BaseStrings.Unit;
        public override bool ShowGroupPanel => false;
        public override bool ShowRightPanel => false;
        public override bool ReadAsync => true;

    }
}

using MicroData.Base.UI.Blazor.Models;
using MicroData.Base.UI.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroData.Base.UI.Blazor.Pages.Unit
{
    public partial class UnitList
    {
        public List<UnitViewModel> Units { get; set; } = default!;


       

        protected override void OnInitialized()
        {
            Units = MockData.Units;
        }

    }
}

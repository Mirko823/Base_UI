using MicroData.Base.UI.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace MicroData.Base.UI.Blazor.Models
{
    public class MockData
    {
        private static List<UnitViewModel>? _units = default!;

        public static List<UnitViewModel>? Units
        {
            get
            {
;

                _units ??= InitializeMockUnits();

                return _units;
            }
        }

        private static List<UnitViewModel> InitializeMockUnits()
        {
            var e1 = new UnitViewModel
            {
                Code = "0000",
                Label = "Kg",
                Name = "Kilogram",
                IsActive = true
            };

             return new List<UnitViewModel>() { e1};
        }


        }
}

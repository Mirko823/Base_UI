using DevExpress.DirectX.Common.Direct3D;
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

            var e2 = new UnitViewModel
            {
                Code = "0001",
                Label = "g",
                Name = "gram",
                IsActive = true
            };
                
            var e3 = new UnitViewModel
                {
                    Code = "0002",
                    Label = "Mg",
                    Name = "Tona",
                    IsActive = true
                };
            var e4 = new UnitViewModel
            {
                Code = "0003",
                Label = "m",
                Name = "metar",
                IsActive = false
            };

            var e5 = new UnitViewModel
            {
                Code = "0004",
                Label = "Km",
                Name = "Kilometar",
                IsActive = false
            };

            return new List<UnitViewModel>() { e1, e2, e3, e4, e5};
        }


        }
}

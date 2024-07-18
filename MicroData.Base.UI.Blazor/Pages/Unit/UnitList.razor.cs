using MicroData.Base.UI.Blazor.Models;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace MicroData.Base.UI.Blazor.Pages.Unit
{
    public partial class UnitList
    {
        [CascadingParameter]
        private HttpContext HttpContext { get; set; } = default!;


        public List<UnitViewModel> Units { get; set; } = default!;

        [Inject]
        public IUnitApi _unitApi { get; set; }


        protected override void OnInitialized()
        {
            //todo test - prebaciti na state
            var x = HttpContext;

            var accessToken = x.User.Claims.FirstOrDefault(c => c.Type.Equals("AccessToken"))?.Value;
            //Units = MockData.Units;
            Units = _unitApi.GetAll(accessToken).ToList();
        }

        private void OnNewButtonClick()
        {
            var unit = new UnitViewModel();
            var editform = new UnitEdit();
            editform.unit = unit;
            Console.WriteLine("OnNewButtonClick called");
            NavigationManager.NavigateTo("/unitedit/new");

        }

    }
}



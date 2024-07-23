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

        [Inject]
        private IHttpContextAccessor httpContextAccessor { get; set; }




        public List<UnitViewModel> Units { get; set; } = default!;

        [Inject]
        public IUnitApi _unitApi { get; set; }


        protected override void OnInitialized()
        {
            //todo test - prebaciti na state
            //var x = HttpContext;

            //if (x == null)
            //    return;

            //var y = httpContextAccessor;

            //var accessToken = x.User.Claims.FirstOrDefault(c => c.Type.Equals("AccessToken"))?.Value;

            //if (accessToken == null)
            //    return;

            Units = _unitApi.GetAll(string.Empty).ToList();

        }

        private void OnNewButtonClick()
        {
            var unit = new UnitViewModel();
            var editform = new UnitEdit();
            editform.unit = unit;
            Console.WriteLine("OnNewButtonClick called");
            NavigationManager.NavigateTo("/unitedit/new");

        }


        private string message = "Poruka pre klika";

        private void ChangeText()
        {
            message = "Dugme je kliknuto!";
        }

      


        bool isPopupVisible = false;

        void ShowPopup()
        {
            isPopupVisible = true;
        }

        void ConfirmDelete()  //proslediti id ili ceo model ovde
        {

            // Your delete logic here
            isPopupVisible = false;
            //
            // _unitApi.DeleteExisting(unitId, string.Empty);
        }

        void CancelDelete()
        {
            isPopupVisible = false;
        }



    }
}



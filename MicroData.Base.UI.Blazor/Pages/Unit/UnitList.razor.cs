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

        private int unitIdToDelete;


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
            
            NavigationManager.NavigateTo("/unitedit/new");

        }



        bool isPopupVisible = false;

        void ShowPopup(int unitId)
        {
            unitIdToDelete = unitId;
            isPopupVisible = true;
           

        }

        void ConfirmDelete()  //proslediti id ili ceo model ovde
        {

            // Your delete logic here
            isPopupVisible = false;
            
            _unitApi.DeleteExisting(unitIdToDelete, string.Empty);
        }

        void CancelDelete()
        {
            isPopupVisible = false;
        }


        private void ToUnitEdit(int UnitId)
        {

            NavigationManager.NavigateTo($"/unitedit/{UnitId}");

        }


    }
}



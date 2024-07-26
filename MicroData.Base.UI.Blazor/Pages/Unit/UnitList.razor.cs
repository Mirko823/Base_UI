using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace MicroData.Base.UI.Blazor.Pages.Unit
{
    public partial class UnitList
    {
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        private int unitIdToDelete;


        public List<UnitViewModel> Units { get; set; } = default!;

        [Inject]
        public IUnitApi _unitApi { get; set; }


        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationState;

            //if (!authState.User.Identity.IsAuthenticated)
            //{
            //    return;
            //}

            //var accessToken = authState.User.Claims.FirstOrDefault(c => c.Type.Equals("AccessToken"))?.Value;
            //if (accessToken != null)
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



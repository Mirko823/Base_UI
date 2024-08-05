using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using DevExpress.Blazor;
using Microsoft.JSInterop;

namespace MicroData.Base.UI.Blazor.Pages.Unit
{
    public partial class UnitList
    {
        //[CascadingParameter]
        //private Task<AuthenticationState> AuthenticationState { get; set; }

        private int unitIdToDelete;


        public List<UnitViewModel> Units { get; set; } = default!;

        [Inject]
        public IUnitApi _unitApi { get; set; }


        protected override async Task OnInitializedAsync()
        {
            //var authState = await AuthenticationState;

            //if (!authState.User.Identity.IsAuthenticated)
            //{
            //    return;
            //}

            //var accessToken = authState.User.Claims.FirstOrDefault(c => c.Type.Equals("AccessToken"))?.Value;
            //if (accessToken != null)
            Units = _unitApi.GetAll(string.Empty).ToList();

            
        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                PageSize = await CalculatePageSizeAsync();
                StateHasChanged(); // Osvježi komponentu nakon ažuriranja PageSize
            }
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
            
            var result = _unitApi.DeleteExisting(unitIdToDelete, string.Empty);

            if (result)
            {
                //1. Nacin  Brzi, nesigurnije (malo sigurniji sa result = true  )
                var itemForDelete = Units.FirstOrDefault(f => f.Id == unitIdToDelete);

                if (itemForDelete != null)
                    Units.Remove(itemForDelete);

                //2.Nacin Spriji, Sigurniji
                //Units = _unitApi.GetAll(string.Empty).ToList();
            }
        }

        void CancelDelete()
        {
            isPopupVisible = false;
        }


        private void ToUnitEdit(int UnitId)
        {

            NavigationManager.NavigateTo($"/unitedit/{UnitId}");

        }


        private int PageSize { get; set; } = 6;

        //IGrid Grid { get; set; }
        ////IEnumerable<UnitViewModel> Data { get; set; }
        //int PageCount { get; set; }
        //int TotalRecords { get; set; }
        //int ActivePageIndex { get; set; } = 0;
        //string RowCountField { get; set; } = "Country";

        //protected override void OnAfterRender(bool firstRender)
        //{
        //    TotalRecords = Units.Count;
        //    PageCount = (int)Math.Ceiling((decimal)TotalRecords / PageSize);
        //    StateHasChanged();
        //    base.OnAfterRender(firstRender);
        //}

        private async Task<int> CalculatePageSizeAsync()
        {
            var viewportHeight = await JSRuntime.InvokeAsync<int>("getViewportHeight");
            // Assume each row is approximately 40px high
            int rowHeight = 40;
            int pageSize = viewportHeight / rowHeight;
            return pageSize;
        }

    }
}



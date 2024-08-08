using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using DevExpress.Blazor;
using Microsoft.JSInterop;
using MicroData.Base.UI.Resource;
using Microsoft.Extensions.Localization;

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

        [Inject]
        private IStringLocalizer<BaseStrings> baseLocalizer1 { get; set; }

        [Parameter]
        public int? PageIndex { get; set; }



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
            RowCountField = baseLocalizer1["CodeUnits"];


            if (PageIndex.HasValue)
            {
                ActivePageIndex = PageIndex.Value;
            }
            else
            {
                ActivePageIndex = 0;
            }


        }



        private void OnNewButtonClick()
        {
            
            NavigationManager.NavigateTo("/unitedit/new?pageIndex={ActivePageIndex}");

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
            //SavePageIndex();
            NavigationManager.NavigateTo($"/unitedit/{UnitId}/{ActivePageIndex}");

        }

        

        private int PageSize { get; set; } = 6;
        //private int PageSizeReal { get; set; } 


        private async Task<int> CalculatePageSizeAsync()
        {
            var viewportHeight = await JSRuntime.InvokeAsync<int>("getViewportHeight");
            // Assume each row is approximately 40px high
            int rowHeight = 50;
            int pageSize = viewportHeight / rowHeight;
            return pageSize;
        }


        IGrid Grid { get; set; }
        int ActivePageIndex { get; set; } = 0;
        int PageCount { get; set; }

        int TotalRecords { get; set; }

        string RowCountField { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
               
                PageSize = await CalculatePageSizeAsync();
                //PageSizeReal = PageSize - 7;

                TotalRecords = (int)(Grid.GetTotalSummaryValue(Grid?.GetTotalSummaryItems().First()));
                PageCount = (int)Math.Ceiling((decimal)TotalRecords / PageSize);
                StateHasChanged(); // Osvježi komponentu nakon ažuriranja PageSize
                base.OnAfterRender(firstRender);
            }
        }
    }
}



using MicroData.Base.UI.Shared.Api;
using MicroData.Base.UI.Shared.Interface;
using MicroData.Base.UI.Shared.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroData.Base.UI.Blazor.Pages.GrainCatalog
{
    public partial class GrainCatalogList
    {
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        [Inject]
        public IGrainCatalogApi _grainCatalogApi { get; set; }
        public List<GrainCatalogViewModel> GrainCatalogs { get; set; } = default!;

        protected async override Task OnInitializedAsync()
        {
             var authState = await AuthenticationState;

            if (!authState.User.Identity.IsAuthenticated)
            {
                return;
            }

            //var accessToken = authState.User.Claims.FirstOrDefault(c => c.Type.Equals("AccessToken"))?.Value;
            //if (accessToken != null)

            var result = await _grainCatalogApi.GetAllAsync(string.Empty);
            GrainCatalogs = result.ToList();
        }


        private void OnNewButtonClick()
        {

            NavigationManager.NavigateTo("/graincatalogedit/new");

        }

    }
}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace MicroData.Base.UI.Blazor.Pages;

/// <summary>
/// App-specific base class for modeling custom pages
/// </summary>
public class PageBase
{

    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationState { get; set; }

    //[Inject]
    //private IHttpContextAccessor httpContextAccessor { get; set; }

    //[Inject]
    //private IdentityUserAccessor userAccessor { get; set; }

    //[Inject]
    //private IUserStore<ApplicationUser> userStore { get; set; }

    public async Task<string> GetAccessToken()
    {
        var authState = await AuthenticationState;
        if (authState != null)
        {
            var user = authState.User;
            var accessToken = user.Claims.FirstOrDefault(c => c.Type.Equals("AccessToken"))?.Value;
            if (accessToken != null)
                return accessToken;

            //var currentUser = userStore.FindByNameAsync(user.Identity.Name.ToUpper(), CancellationToken.None).Result;

            //if (currentUser != null)
            //    return currentUser.AccessToken;
        }

        return string.Empty;
    }


}

using MicroData.Base.UI.Shared.Api;
using MicroData.Base.UI.Shared.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace MicroData.Base.UI.Shared.Helper
{
    public static class InitBaseHellper
    {
        private static bool isRegistered = false;
        private static ServiceProvider serviceProvider;

        public static void ConfigureService()
        {
            if (isRegistered)
                return;

            ServiceCollection services = new ServiceCollection();
            DependencyInjectionHellper.ConfigureService(services);

            serviceProvider = services.BuildServiceProvider();

            isRegistered = true;
        }

        public static T GetDependencyService<T>()
        {
            return serviceProvider.GetService<T>();
        }

    }
}

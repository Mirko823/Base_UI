using AutoMapper;

namespace MicroData.Identity.UI.Shared.App.Mapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
             {
                 cfg.AddProfile(new ModelToViewModelProfile());
                 cfg.AddProfile(new ViewModelToModelProfile());
             });
        }
    }
}

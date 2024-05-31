using AutoMapper;

namespace MicroData.Base.UI.Shared.App.Mapper
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

using AutoMapper;

namespace AnnaLeaoStoreMVC.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()

        {
            Mapper.Initialize(x =>
            {
                x.AddProfile(new DomainToViewModelMappingProfile());
                x.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }

    }
}
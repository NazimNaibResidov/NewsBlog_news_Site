using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NewsBlog.Constants;

namespace NewsBlog.Extensions
{
    public static class MapperExtension
    {
        public static void LoaderMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DTOMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}

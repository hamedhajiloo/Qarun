using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Services.CustomMapping
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeAutoMapper()
        {
            Assembly entitiesAssembly = typeof(IUserService).Assembly;

            Mapper.Initialize(config =>
            {
                config.AddCustomMappingProfile(entitiesAssembly);
            });

            //Compile mapping after configuration to boost map speed
            Mapper.Configuration.CompileMappings();
        }

        public static void AddCustomMappingProfile(this IMapperConfigurationExpression config)
        {
            config.AddCustomMappingProfile(Assembly.GetEntryAssembly());
        }

        public static void AddCustomMappingProfile(this IMapperConfigurationExpression config, params Assembly[] assemblies)
        {
            System.Collections.Generic.IEnumerable<Type> allTypes = assemblies.SelectMany(a => a.ExportedTypes);

            System.Collections.Generic.IEnumerable<IHaveCustomMapping> list = allTypes.Where(type => type.IsClass && !type.IsAbstract &&
                type.GetInterfaces().Contains(typeof(IHaveCustomMapping)))
                .Select(type => (IHaveCustomMapping)Activator.CreateInstance(type));

            CustomMappingProfile profile = new CustomMappingProfile(list);

            config.AddProfile(profile);
        }
    }
}

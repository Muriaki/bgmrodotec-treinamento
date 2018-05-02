using AutoMapper;
using BgmRodotec.Treinamento.NHibernate.Profiles;

namespace BgmRodotec.Treinamento.NHibernate.Configuration
{
    public class ConfigureAutoMapper
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });
        }
    }
}
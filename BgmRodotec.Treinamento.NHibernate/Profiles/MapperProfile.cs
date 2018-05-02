using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BgmRodotec.Treinamento.NHibernate.DataTransferObject;
using BgmRodotec.Treinamento.NHibernate.Models;

namespace BgmRodotec.Treinamento.NHibernate.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Pessoa, PessoaEnderecoTelefoneTipoDto>()
                .ForMember(m => m.Numero, opt => opt.MapFrom(m => m.Telefones.Select(t => t.Numero).FirstOrDefault()))
                .ForMember(m => m.Tipo, opt => opt.MapFrom(m => m.Telefones.Select(t => t.TipoTelefone.Tipo).FirstOrDefault()))
                .ForMember(m => m.Rua, opt => opt.MapFrom(m => m.Enderecos.Select(e => e.Rua).FirstOrDefault()));

            CreateMap<Pessoa, PessoaWithCollectionsSetDto>()
                .ForMember(m => m.Enderecos, opt => opt.MapFrom(m => ToISet<Endereco, EnderecoDto>(m.Enderecos)))
                .ForMember(m => m.Telefones, opt => opt.MapFrom(m => ToISet<Telefone, TelefoneDto>(m.Telefones)));

            CreateMap<Pessoa, PessoaWithManyToManySetDto>()
                .ForMember(m => m.Carros, opt => opt.MapFrom(m => ToISet<Carro, CarroDto>(m.Carros)));
        }
        
        private static ISet<TDestination> ToISet<TSource, TDestination>(IEnumerable<TSource> source)
        {
            ISet<TDestination> set = null;
            if (source != null)
            {
                set = new HashSet<TDestination>();

                foreach (TSource item in source)
                {
                    set.Add(Mapper.Map<TSource, TDestination>(item));
                }
            }
            return set;
        }
    }
}
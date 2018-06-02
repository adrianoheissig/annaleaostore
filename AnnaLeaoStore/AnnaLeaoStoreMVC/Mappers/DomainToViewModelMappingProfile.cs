using AnnaLeaoStore.Model;
using AnnaLeaoStoreMVC.ViewModels;
using AutoMapper;

namespace AnnaLeaoStoreMVC.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produtos, ProdutosViewModel>();
            CreateMap<Pessoas, PessoasViewModel>();
            CreateMap<Contatos, ContatosViewModel>();
        }
    }

}
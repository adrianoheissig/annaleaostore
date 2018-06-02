using AnnaLeaoStore.Model;
using AnnaLeaoStoreMVC.ViewModels;
using AutoMapper;


namespace AnnaLeaoStoreMVC.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutosViewModel, Produtos>();
            CreateMap<PessoasViewModel, Pessoas>();
            CreateMap<ContatosViewModel, Contatos>();
        }
    }

}
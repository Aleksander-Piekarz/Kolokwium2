using AutoMapper;
using Kolokwium.Model.DataModels;
using Kolokwium.ViewModel.VM;
namespace Kolokwium.Services.Configuration.AutoMapperProfiles;
public class MainProfile : Profile
{
    public MainProfile()
    {
         CreateMap<Ksiazka, KsiazkiVm>()
            .ForMember(dest => dest.ImieNazwiskoAutora,
                opt => opt.MapFrom(src => src.Autor.Imie + " " + src.Autor.Nazwisko));
            CreateMap<AddKsiazkaVm, Ksiazka>();
            
    }
}

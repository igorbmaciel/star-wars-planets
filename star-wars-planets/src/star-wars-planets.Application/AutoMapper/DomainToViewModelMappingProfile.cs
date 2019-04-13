using AutoMapper;
using star_wars_planets.Application.ViewModels;
using star_wars_planets.Domain.Models;

namespace star_wars_planets.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Planet, PlanetViewModel>();
        }
    }
}

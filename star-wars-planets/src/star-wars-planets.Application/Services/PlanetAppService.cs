using AutoMapper;
using star_wars_planets.Application.Interfaces;
using star_wars_planets.Application.ViewModels;
using star_wars_planets.Domain.Interfaces;
using star_wars_planets.Domain.Models;
using System;
using System.Collections.Generic;

namespace star_wars_planets.Application.Services
{
    public class PlanetAppService : IPlanetAppService
    {
        private readonly IPlanetService _planetService;

        public PlanetAppService(IPlanetService planetService) : base()
        {
            _planetService = planetService;
        }

        public void Dispose()
        {
            _planetService.Dispose();
            GC.SuppressFinalize(this);
        }

        public PlanetViewModel Add(PlanetViewModel planetViewModel)
        {
            var planet = Mapper.Map<PlanetViewModel, Planet>(planetViewModel);        

            var planetReturn = _planetService.Add(planet);
            planetViewModel = Mapper.Map<Planet, PlanetViewModel>(planetReturn);

            return planetViewModel;
        }

        public IEnumerable<PlanetViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Planet>, IEnumerable<PlanetViewModel>>(_planetService.GetAll());
        }

        public PlanetViewModel GetById(int id)
        {
            return Mapper.Map<Planet, PlanetViewModel>(_planetService.GetById(id));
        }

        public PlanetViewModel GetByName(string name)
        {
            return Mapper.Map<Planet, PlanetViewModel>(_planetService.GetByName(name));
        }

        public void Remove(int id)
        {
            _planetService.Remove(id);
        }
    }
}

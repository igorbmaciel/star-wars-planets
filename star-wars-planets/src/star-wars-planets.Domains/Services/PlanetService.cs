using System;
using System.Collections.Generic;
using star_wars_planets.Domain.Interfaces;
using star_wars_planets.Domain.Models;

namespace star_wars_planets.Domain.Services
{
    public class PlanetService : IPlanetService
    {
        private readonly IPlanetRepository _planetRepository;

        public PlanetService(IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository;
        }

        public Planet Add(Planet planet)
        {
            //TODO: Realizar buscar de quantidade de filmes
            return _planetRepository.Add(planet);
        }

        public void Dispose()
        {
            _planetRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Planet> GetAll()
        {
            return _planetRepository.GetAll();
        }

        public Planet GetById(int id)
        {
            return _planetRepository.GetById(id);
        }

        public Planet GetByName(string name)
        {
            return _planetRepository.GetByName(name);
        }

        public void Remove(int id)
        {
            _planetRepository.Remove(id);
        }
    }
}

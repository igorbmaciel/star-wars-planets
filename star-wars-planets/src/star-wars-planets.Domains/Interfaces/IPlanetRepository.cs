using star_wars_planets.Domain.Models;
using System;
using System.Collections.Generic;

namespace star_wars_planets.Domain.Interfaces
{
    public interface IPlanetRepository : IDisposable
    {
        Planet Add(Planet planet);
        Planet GetById(int id);
        Planet GetByName(string name);
        IEnumerable<Planet> GetAll();
        void Remove(int planet);
    }
}

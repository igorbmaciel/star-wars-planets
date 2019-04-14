using star_wars_planets.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace star_wars_planets.Application.Interfaces
{
    public interface IPlanetAppService
    {
        Task<PlanetViewModel> Add(PlanetViewModel planet);
        PlanetViewModel GetById(int id);
        PlanetViewModel GetByName(string name);
        IEnumerable<PlanetViewModel> GetAll();
        void Remove(int id);
    }
}

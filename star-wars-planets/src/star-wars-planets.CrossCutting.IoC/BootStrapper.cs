using SimpleInjector;
using star_wars_planets.Application.Interfaces;
using star_wars_planets.Application.Services;
using star_wars_planets.Data.Context;
using star_wars_planets.Data.Repositories;
using star_wars_planets.Domain.Interfaces;
using star_wars_planets.Domain.Services;

namespace star_wars_planets.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // App
            container.Register<IPlanetAppService, PlanetAppService>(Lifestyle.Singleton);           

            // Domain
            container.Register<IPlanetService, PlanetService>(Lifestyle.Singleton);      

            // Infra Dados
            container.Register<IPlanetRepository, PlanetRepository>(Lifestyle.Singleton);
            container.Register<PlanetsContext>(Lifestyle.Singleton);

        }
    }
}

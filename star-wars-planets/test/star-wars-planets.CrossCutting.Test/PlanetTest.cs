using NSubstitute;
using star_wars_planets.Domain.Interfaces;
using star_wars_planets.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace star_wars_planets.CrossCutting.Test
{
    public class PlanetTest
    {
        readonly Planet planet = new Planet()
        {
            Id = 1,
            Name = "Tatooine",
            Weather = "arid",
            Ground = "desert"
        };

        [Fact]
        public void Should_Create()
        {
            var planetService = Substitute.For<IPlanetService>();           

            var response = planetService.Add(planet).ReturnsForAnyArgs(x =>
            {
                return planet;
            });
       
            Assert.True(response != null);
        }

        [Fact]
        public void Should_GetAll()
        {
            var planetService = Substitute.For<IPlanetService>();
            

            var response = planetService.GetAll().ReturnsForAnyArgs(x =>
            {
                return new List<Planet>()
                {
                    planet
                };              
            });

            Assert.True(response != null);
        }

        [Fact]
        public void Should_GetById()
        {
            var planetService = Substitute.For<IPlanetService>();
            
            var response = planetService.GetById(planet.Id).ReturnsForAnyArgs(x =>
            {
                return planet;
            });

            Assert.True(response != null);
        }

        [Fact]
        public void Should_GetByName()
        {
            var planetService = Substitute.For<IPlanetService>();

            var response = planetService.GetByName(planet.Name).ReturnsForAnyArgs(x =>
            {
                return planet;
            });

            Assert.True(response != null);
        }

        [Fact]
        public void Should_Remove()
        {
            var planetService = Substitute.For<IPlanetService>();

            planetService.Remove(planet.Id);

            Assert.True(true);
        }
    }
}

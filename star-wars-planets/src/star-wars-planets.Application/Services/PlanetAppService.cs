using AutoMapper;
using Newtonsoft.Json.Linq;
using star_wars_planets.Application.Interfaces;
using star_wars_planets.Application.ViewModels;
using star_wars_planets.Domain.Interfaces;
using star_wars_planets.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;

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

        public async Task<PlanetViewModel> Add(PlanetViewModel planetViewModel)
        {
            var teste  = await GetMovieQuantity(planetViewModel);

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

        private async Task<PlanetViewModel> GetMovieQuantity(PlanetViewModel planetViewModel)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://swapi.co/")
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                planetViewModel = await GetPlanetAsync(planetViewModel, client);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return planetViewModel;
        }

        private async Task<PlanetViewModel> GetPlanetAsync(PlanetViewModel planetViewModel, HttpClient client)
        {
            var response = await client.GetAsync($"api/planets/{planetViewModel.Id}/");
            if (response.IsSuccessStatusCode)
            {
                var planet = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(planet);
                var movieQuantity = json.GetValue("films").ToList();
                planetViewModel.MovieQuantity = movieQuantity.Count;
            }            

            return planetViewModel;
        }
       
    }
}

using star_wars_planets.Application.Interfaces;
using star_wars_planets.Application.ViewModels;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace star_wars_planets.Services.REST.API.Controllers
{
    public class PlanetController : ApiController
    {
        private readonly IPlanetAppService _planetAppService;

        public PlanetController(IPlanetAppService planetAppService)
        {
            _planetAppService = planetAppService;
        }

        [HttpPost]
        [Route("Planet")]
        [ResponseType(typeof(PlanetViewModel))]
        public async Task<HttpResponseMessage> Post([FromBody]PlanetViewModel planetViewModel)
        {
            var configuration = new HttpConfiguration();
            var request = new HttpRequestMessage();
            request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = configuration;

            var planet = await _planetAppService.Add(planetViewModel);

            return request.CreateResponse(HttpStatusCode.OK, planet);
        }

        [HttpGet]
        [Route("Planet")]
        [ResponseType(typeof(PlanetViewModel))]
        public HttpResponseMessage GetAll()
        {
            var configuration = new HttpConfiguration();
            var request = new HttpRequestMessage();
            request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = configuration;

            var planet = _planetAppService.GetAll();

            return request.CreateResponse(HttpStatusCode.OK, planet);
        }

        [HttpGet]
        [Route("Planet/Id/{id}")]
        [ResponseType(typeof(PlanetViewModel))]
        public HttpResponseMessage Get(int id)
        {
            var configuration = new HttpConfiguration();
            var request = new HttpRequestMessage();
            request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = configuration;

            var planet = _planetAppService.GetById(id);

            return request.CreateResponse(HttpStatusCode.OK, planet);
        }

        [HttpGet]
        [Route("Planet/Name/{name}")]
        [ResponseType(typeof(PlanetViewModel))]
        public HttpResponseMessage Get(string name)
        {
            var configuration = new HttpConfiguration();
            var request = new HttpRequestMessage();
            request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = configuration;

            var planet = _planetAppService.GetByName(name);

            return request.CreateResponse(HttpStatusCode.OK, planet);
        }

        [HttpDelete]
        [Route("Planet/{id}")]
        [ResponseType(typeof(PlanetViewModel))]
        public HttpResponseMessage Deelte(int id)
        {
            var configuration = new HttpConfiguration();
            var request = new HttpRequestMessage();
            request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = configuration;

            _planetAppService.Remove(id);

            return request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

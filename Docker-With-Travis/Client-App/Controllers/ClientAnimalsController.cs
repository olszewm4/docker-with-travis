using Client_App.Models;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientAnimalsController : ControllerBase
    {
        private readonly ServiceConfiguration _serviceConfiguration;

        public ClientAnimalsController(ServiceConfiguration serviceConfiguration)
        {
            _serviceConfiguration = serviceConfiguration;
        }

        // GET api/values
        [HttpGet]
        public async Task<List<AnimalDto>> Get()
        {
            return await new Uri(_serviceConfiguration.Url + "/api/animals")
                .AbsoluteUri
                .GetAsync()
                .ReceiveJson<List<AnimalDto>>();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<AnimalDto> Get(int id)
        {
            return await new Uri(_serviceConfiguration.Url + $"/api/animals/{id}")
                .AbsoluteUri
                .GetAsync()
                .ReceiveJson<AnimalDto>();
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] string value)
        {
            await new Uri(_serviceConfiguration.Url + "/api/animals")
                .AbsoluteUri
                .PostJsonAsync(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await new Uri(_serviceConfiguration.Url + $"/api/animals/{id}")
                .AbsoluteUri
                .DeleteAsync();
        }
    }
}

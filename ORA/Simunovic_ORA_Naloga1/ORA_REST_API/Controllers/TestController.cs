using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ORA_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/<TestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            using (TriatlonContext context = new TriatlonContext())
            {
                Results results = context.Results.Where(x => x.ID == id).Single();
                return results.Name;
            }
        }

        [HttpGet("/Results")]
        public string Get([FromQuery]string name)
        {
            using(TriatlonContext context = new TriatlonContext())
            {
                var results = context.Results.Where(x=>x.Name.Contains(name)).ToList();
                var json = JsonSerializer.Serialize(results, new JsonSerializerOptions
                {
                    WriteIndented = true,
                });
                return json;
            }
        }
        [HttpGet("{age}")]
        public string GetByAge(string age)
        {
            using(TriatlonContext context = new TriatlonContext())
            {
                Results results = context.Results.Where(x=>x.Age == age).Single();
                return results.Name;
            }
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

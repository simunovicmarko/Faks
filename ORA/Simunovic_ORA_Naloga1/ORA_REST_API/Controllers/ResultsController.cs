using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ORA_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        // GET: api/<ResultsController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{

        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        public string Get()
        {
            using (TriatlonContext context = new TriatlonContext())
            {
                var results = context.Results.Take(100).ToList();
                var json = JsonSerializer.Serialize(results, new JsonSerializerOptions
                {
                    WriteIndented = true,
                });
                return json;
            }
        }



        // GET api/<ResultsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            using (TriatlonContext context = new TriatlonContext())
            {
                Results results = context.Results.Where(result => result.ID == id).FirstOrDefault();
                var json = JsonSerializer.Serialize(results, new JsonSerializerOptions
                {
                    WriteIndented = true,
                });
                return json;
                //return results;
            }
        }
        [HttpGet("Athlete")]
        public string Get([FromQuery]string name)
        {
            using (TriatlonContext context = new TriatlonContext())
            {
                Results results = context.Results.Where(result => result.Name.Contains(name)).FirstOrDefault();
                var json = JsonSerializer.Serialize(results, new JsonSerializerOptions
                {
                    WriteIndented = true,
                });
                return json;
                //return results;
            }
        }

        // POST api/<ResultsController>
        [HttpPost("AddResult")]
        public void Post([FromBody] Results results)
        {
            using (TriatlonContext context = new TriatlonContext())
            {
                //results.ID = null;
                context.Results.Add(results);
                context.SaveChanges();
                //return results;
            }
        }

        // PUT api/<ResultsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Results results)
        {
        }

        // DELETE api/<ResultsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

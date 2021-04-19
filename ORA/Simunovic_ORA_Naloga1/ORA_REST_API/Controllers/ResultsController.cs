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
        [HttpGet]
        public string Get()
        {
            TriatlonContext context = TriatlonContext.Instance;

            var results = context.Results.Take(100).ToList();
            var json = JsonSerializer.Serialize(results, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
            return json;
        }



        // GET api/<ResultsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            TriatlonContext context = TriatlonContext.Instance;
            Results results = context.Results.Where(result => result.ID == id).FirstOrDefault();
            var json = JsonSerializer.Serialize(results, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
            return json;
            //return results;

        }
        [HttpGet("Athlete")]
        public string Get([FromQuery] string name)
        {
            TriatlonContext context = TriatlonContext.Instance;
            Results results = context.Results.Where(result => result.Name.Contains(name)).FirstOrDefault();
            var json = JsonSerializer.Serialize(results, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
            return json;
            //return results;

        }

        // POST api/<ResultsController>
        [HttpPost("AddResult")]
        public IActionResult Post([FromBody] Results results)
        {
            TriatlonContext context = TriatlonContext.Instance;
            try
            {
                context.Results.Add(results);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        //
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Results results)
        {
            TriatlonContext context = TriatlonContext.Instance;
            try
            {
                Results result = context.Results.Where(x => x.ID == id).First();
                UpdateResults(results, ref result);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
                //throw;
            }

        }

        private static void UpdateResults(Results results, ref Results result)
        {
            result.Age = results.Age;
            result.Bib = results.Bib;
            result.Bike = results.Bike;
            result.BikeDistance = results.BikeDistance;
            //result.Competitions = results.Competitions;
            result.Country = results.Country;
            result.Division = results.Division;
            result.DivRank = results.DivRank;
            result.GenderRank = results.GenderRank;
            result.Name = results.Name;
            result.Overall = results.Overall;
            result.OverallRank = results.OverallRank;
            result.Points = results.Points;
            result.Profession = results.Profession;
            result.Run = results.Run;
            result.RunDistance = results.RunDistance;
            result.State = results.State;
            result.Swim = results.Swim;
            result.SwimDistance = results.SwimDistance;
            result.T1 = results.T1;
            result.T2 = results.T2;
        }

        //DELETE api/<ResultsController>/5
        [HttpDelete]
        public IActionResult Delete([FromBody] int id)
        {
            TriatlonContext context = TriatlonContext.Instance;
            try
            {
                context.Results.Remove(context.Results.Where(x => x.ID == id).First());
                context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}

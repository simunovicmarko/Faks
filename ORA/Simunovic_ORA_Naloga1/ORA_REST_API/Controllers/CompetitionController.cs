using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORA_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                TriatlonContext context = TriatlonContext.Instance;
                var competitions = context.Competitions.Take(100);
                return Ok(competitions);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                TriatlonContext context = TriatlonContext.Instance;
                Competition competition = context.Competitions.Where(x => x.ID == id).FirstOrDefault();
                return Ok(competition);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Competition competition)
        {
            try
            {
                TriatlonContext context = TriatlonContext.Instance;
                context.Competitions.Add(competition);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

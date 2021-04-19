using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ORA_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                TriatlonContext context = TriatlonContext.Instance;

                var results = context.Users.Take(100).ToList();
                var json = JsonSerializer.Serialize(results, new JsonSerializerOptions
                {
                    WriteIndented = true,
                });
                return Ok(json);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public IActionResult PostAdd(User user)
        {
            TriatlonContext context = TriatlonContext.Instance;
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();

            }

        }

        [HttpPost("login")]
        public IActionResult PostLogin([FromBody] User user)
        {
            TriatlonContext context = TriatlonContext.Instance;
            var user1 = context.Users.Where(u => u.Email == user.Email && u.password == user.password).FirstOrDefault();
            if (user1 != null)
                return Ok(user1);
            return NotFound();

        }


        [HttpDelete]
        public IActionResult Delete([FromBody] int id)
        {
            TriatlonContext context = TriatlonContext.Instance;
            try
            {
                context.Users.Remove(context.Users.Where(x => x.ID == id).First());
                context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
    }
}

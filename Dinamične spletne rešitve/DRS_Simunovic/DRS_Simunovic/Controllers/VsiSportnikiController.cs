using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRS_Simunovic.Controllers
{
    public class VsiSportnikiController : Controller
    {
        public IActionResult Index()
        {
            AtletikaContext context = AtletikaContext.Instance;
            var sportniki = context.Sportniks.Where(x => x.ID != -1).ToList();


            return View();
        }
    }
}

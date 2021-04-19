using DRS_Simunovic.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRS_Simunovic.Controllers
{
    public class SportnikController : Controller
    {

        public IActionResult Index()
        {
            AtletikaContext context = AtletikaContext.Instance;
            VsiSportniki vsiSportniki = new VsiSportniki();
            vsiSportniki.sportniks = context.Sportniks.Where(x => x.ID != -1).ToList();
            return View(vsiSportniki);
        }

       
        [HttpPost]
        public IActionResult Dodajanje(Sportnik sportnik)
        {
            if (sportnik.DoubleDaPokažemDaDela > 100)
            {
                sportnik.DoubleDaPokažemDaDela = sportnik.DoubleDaPokažemDaDela / 10.0;
            }

            AtletikaContext context = AtletikaContext.Instance;
            context.Sportniks.Add(sportnik);
            context.SaveChanges();

            return RedirectToAction("PrikazPodatkov", sportnik);
        }

        public IActionResult PrikazPodatkov(Sportnik sportnik)
        {
            return View(sportnik);
        }


        [HttpGet]
        public IActionResult Dodajanje()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Uredi(Sportnik sportnik)
        {
            if (sportnik != null)
            {
                return View(sportnik);
            }
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
         public IActionResult UrediSportnika(Sportnik sportnik)
        {
            if (sportnik != null)
            {
                AtletikaContext context = AtletikaContext.Instance;
                var sp = context.Sportniks.Where(x => x.ID == sportnik.ID).Single();
                sp.Name = sportnik.Name;
                sp.LastName = sportnik.LastName;
                context.SaveChanges();
                return RedirectToAction("PrikazPodatkov", sportnik);
            }
            else
                return RedirectToAction("Index");
        }

        public IActionResult Izbrisi(Sportnik sportnik)
        {
            AtletikaContext context = AtletikaContext.Instance;
            context.Sportniks.Remove(context.Sportniks.Where(x => x.ID == sportnik.ID).SingleOrDefault());
            context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}

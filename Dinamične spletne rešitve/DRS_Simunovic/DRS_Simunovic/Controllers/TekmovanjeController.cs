using DRS_Simunovic.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRS_Simunovic.Controllers
{
    public class TekmovanjeController : Controller
    {
        public IActionResult Index()
        {
            List<Tekmovanje> tekmovanjes = AtletikaContext.Instance.tekmovanjes.Where(x => x.ID != -1).ToList();
            VsaTekmovanja vsaTekmovanja = new VsaTekmovanja();
            vsaTekmovanja.Tekmovanjes = tekmovanjes;
            return View(vsaTekmovanja);
        }
        
        
        public IActionResult Dodajanje()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Dodajanje(Tekmovanje tekmovanje)
        {
            AtletikaContext context = AtletikaContext.Instance;
            context.tekmovanjes.Add(tekmovanje);
            context.SaveChanges();
            return RedirectToAction("PrikazPodatkov", tekmovanje);
        }

        public IActionResult PrikazPodatkov(Tekmovanje tekmovanje)
        {
            return View(tekmovanje);
        }

        [HttpGet]
        public IActionResult Uredi(Tekmovanje tekmovanje)
        {
            if (tekmovanje != null)
            {
                return View(tekmovanje);
            }
            else
                return RedirectToAction("Index");
        }

        public IActionResult UrediTekmovanje(Tekmovanje tekmovanje)
        {
            AtletikaContext context = AtletikaContext.Instance;
            var tekma = context.tekmovanjes.Where(x => x.ID == tekmovanje.ID).Single();
            tekma.Name = tekmovanje.Name;
            tekma.venue = tekmovanje.venue;

            context.SaveChanges();
            return RedirectToAction("PrikazPodatkov", tekmovanje);
        }

        //[HttpDelete]
        public IActionResult Izbrisi(Tekmovanje tekmovanje)
        {
            AtletikaContext context = AtletikaContext.Instance;
            context.tekmovanjes.Remove(context.tekmovanjes.Where(x => x.ID == tekmovanje.ID).SingleOrDefault());
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

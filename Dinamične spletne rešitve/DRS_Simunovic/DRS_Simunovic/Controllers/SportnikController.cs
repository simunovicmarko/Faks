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
            Sportnik s = new Sportnik();
            s.Name = "Marko";
            s.LastName = "Šimunović";
            s.dateOfBirtth = new DateTime(2000, 5, 12).Date;

            ViewBag.name = s.Name;
            ViewBag.lastname = s.LastName;
            ViewBag.date = s.dateOfBirtth.ToString("dd. MM. yyyy");
            return View();
        }

        public IActionResult Tekmovanje(Sportnik s) 
        {
            //ViewBag.name = s.Name;
            //ViewBag.date = datum;
            //ViewBag.lastname = priimek;
            //ViewBag.competition = tekmovanje;
            //ViewBag.place = prizorisce;

            return View();
        }
    }
}

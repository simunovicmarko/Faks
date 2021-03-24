using DRS_Simunovic.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRS_Simunovic.Controllers
{
    public class RegistrationController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            Uporabnik u = new Uporabnik();
            return View();
        }

        [HttpPost]
        public IActionResult VpisOsnovnihPodatkov(Uporabnik u)
        {
            TempData["Uporabnik"] = "xxx";
            TempData["DataIme"] = u.Ime;
            TempData["DataPriimek"] = u.Priimek;
            TempData["DataEmso"] = u.EMŠO;
            TempData["DataDatumRojstva"] = u.DatumRojstva;
            return RedirectToAction("VpisNaslova");

        }

        [HttpGet]
        public IActionResult VpisNaslova()
        {
            if (TempData["Uporabnik"] == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult VpisNaslova(NaslovUporabnika nu)
        {
            TempData["Naslov"] = nu.Naslov;
            TempData["DataNaslov"] = nu.Naslov;
            TempData["DataPostnaStevilka"] = nu.PostnaStevilka;
            TempData["DataDrzava"] = nu.Drzava;
            return RedirectToAction("VpisVpisnihPodatkov");
        }


        [HttpGet]
        public IActionResult VpisVpisnihPodatkov()
        {
            if (TempData["Naslov"] == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpPost]
        public IActionResult VpisVpisnihPodatkov(VpisniPodatki vp)
        {
            TempData["VpisniPodatki"] = "vp";
            TempData["DataEposta"] = vp.Eposta;
            TempData["DataGeslo"] = vp.Geslo;
            if (vp.Geslo == vp.Geslo1)
            {

                return RedirectToAction("PrikazPodatkov");
            }

                return RedirectToAction("Index");
        }


        public IActionResult PrikazPodatkov()
        {
            if (TempData["VpisniPodatki"] == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.ime = TempData["DataIme"];
            ViewBag.priimek = TempData["DataPriimek"];
            ViewBag.emso = TempData["DataEmso"];
            ViewBag.datumRojstva = TempData["DataDatumRojstva"];
            ViewBag.naslov = TempData["DataNaslov"];
            ViewBag.postna = TempData["DataPostnaStevilka"];
            ViewBag.drzava = TempData["DataDrzava"];
            ViewBag.eposta = TempData["DataEposta"];
            ViewBag.geslo = TempData["DataGeslo"];
            return View();
        }

    }
}

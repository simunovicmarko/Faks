using DRS_Simunovic.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;
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
            Uporabnik uporabnik = new Uporabnik();
            return View(uporabnik);
        }

        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly UserManager<IdentityUser> _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());



        [HttpPost]
        public async Task<IActionResult> Index(Uporabnik uporabnik)
        {
            if (ModelState.IsValid)
            {

                IdentityUser user = new IdentityUser { UserName = uporabnik.Eposta, Email = uporabnik.Eposta };
                //RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole, "Admin">();
                UserManager<IdentityUser> _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(AtletikaContext.Instance));
                var result = await _userManager.CreateAsync(user, uporabnik.Geslo);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user.Id, "User");
                    TempData["Uporabnik"] = "xxx";

                    AtletikaContext context = AtletikaContext.Instance;
                    context.uporabniks.Add(uporabnik);
                    await context.SaveChangesAsync();

                    return RedirectToAction("PrikazPodatkov", uporabnik);
                }

            }
            return View();
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


        public IActionResult PrikazPodatkov(Uporabnik uporabnik)
        {
            if (TempData["Uporabnik"] == null)
            {
                return RedirectToAction("Index");
            }


            return View(uporabnik);
        }

    }
}

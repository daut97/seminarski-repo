using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using seminarski.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Klase;
using seminarski.Data;

namespace seminarski.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ListaAuta()
        {
            ApplicationDbContext db=new ApplicationDbContext();
            List<AutoVM> lista = db.Auto.Select(x => new AutoVM {
                ID = x.AutoID,
                Proizvodjac = x.Proizvodjac.Naziv,
                Model=x.Model,
                Boja=x.Boja,
                Godiste=x.Godiste

            }).ToList();
            ViewData["key"] = lista;
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Obrisi(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Auto a = db.Auto.Where(x => x.AutoID == id).SingleOrDefault();
            db.Remove(a);
            db.SaveChanges();

            return Redirect("/Home/listaauta");
        }
        public IActionResult Dodaj(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            ViewBag.Proizvodjaci = db.Proizvodjac.ToList();
            return View();
        }
        public IActionResult Snimi(int proizvodjacid,string model,string boja,string godiste,bool novo)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Auto a = new Auto { ProizvodjacID = proizvodjacid, Model = model, Boja = boja, Godiste = godiste, Novo = novo };
            db.Add(a);
            db.SaveChanges();

            
            return Redirect("/home/ListaAuta");
        }
        public IActionResult Dodaj1(int id)
        {
            return View();
        }
    }
}

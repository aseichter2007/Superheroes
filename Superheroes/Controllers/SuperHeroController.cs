using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superheroes.Data;
using Superheroes.Models;

namespace Superheroes.Controllers
{
    public class SuperHeroController : Controller
    {
        ApplicationDbContext _Context;
        public SuperHeroController(ApplicationDbContext _Context)
        {
            this._Context = _Context;
        }
        // GET: SuperHero
        public ActionResult Index()
        {
            List<SuperHero> heroes = _Context.heroes.ToList();
            return View(heroes);
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int id)
        {
            SuperHero hero = _Context.heroes.Where(h => h.Id == id).Single();
            return View(hero);
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            SuperHero hero = new SuperHero();
            return View(hero);
        }

        // POST: SuperHero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero hero)
        {
            
            try
            {
                var notfavorite = _Context.heroes.Where(h => h.favorite == true);
                foreach (var item in notfavorite)
                {
                    item.favorite = false;
                }
                _Context.heroes.Add(hero);
                _Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)
        {
            SuperHero hero = _Context.heroes.Where(h => h.Id == id).Single();

            return View(hero);
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SuperHero hero)
        {
            try
            {
                if (hero.favorite==true)
                {
                    var notfavorite = _Context.heroes.Where(h => h.favorite == true);
                    foreach (var item in notfavorite)
                    {
                        item.favorite = false;
                    }
                }
                _Context.heroes.Update(hero);
                _Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Delete/5
        public ActionResult Delete(int id)
        {
            SuperHero hero = _Context.heroes.Where(h => h.Id == id).Single();

            return View(hero);
        }

        // POST: SuperHero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SuperHero hero)
        {
            try
            {
                 //SuperHero hero = _Context.heroes.Find(id);
                 _Context.heroes.Remove(hero);
                 _Context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
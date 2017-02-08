using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LeagueOrganizer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LeagueOrganizer.Controllers
{
    public class PlayersController : Controller
    {
        private LeagueContext db = new LeagueContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Players.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Player newPlayer)
        {
            db.Players.Add(newPlayer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

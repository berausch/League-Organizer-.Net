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

        public IActionResult Edit(int id)
        {
            var selectedPlayer = db.Players.FirstOrDefault(players => players.PlayerId == id);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name");
            return View(selectedPlayer);
        }
        [HttpPost]
        public IActionResult Edit(Player player)
        {
            db.Entry(player).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var selectPlayer = db.Players
                .Include(players => players.Team)
                .FirstOrDefault(players => players.PlayerId == id);

            var playerDivId = db.Teams.FirstOrDefault(teams => teams.TeamId == selectPlayer.TeamId);

            var playerDiv = db.Divisions.FirstOrDefault(divisions => divisions.DivId == playerDivId.DivId);

            ViewBag.playerDiv = playerDiv.Name;

            return View(selectPlayer);
        }

        public IActionResult Delete(int id)
        {
            var thisPlayer = db.Players.FirstOrDefault(players => players.PlayerId == id);
            return View(thisPlayer);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisPlayer = db.Players.FirstOrDefault(players => players.PlayerId == id);
            db.Players.Remove(thisPlayer);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using LeagueOrganizer.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LeagueOrganizer.Controllers
{
    public class TeamsController : Controller
    {
        private LeagueContext db = new LeagueContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Teams.ToList());
        }
        public IActionResult Details(int id)
        {
            var selectTeam = db.Teams
                .Include(teams => teams.Players)
                .Include(teams => teams.Division)
                .FirstOrDefault(teams => teams.TeamId == id);
            if(selectTeam.CaptId == 0)
            {
                ViewBag.Captain = "None";

            } else {

                var captain = db.Players.FirstOrDefault(players => players.PlayerId == selectTeam.CaptId);

                ViewBag.Captain = captain.FName + " " + captain.LName;
            }

            return View(selectTeam);
        }

        public IActionResult Edit(int id)
        {
            var selectedTeam = db.Teams.FirstOrDefault(teams => teams.TeamId == id);
            ViewBag.DivId = new SelectList(db.Divisions, "DivId", "Name");
            ViewBag.CaptId = new SelectList(db.Players.Where(p => p.TeamId == id), "PlayerId", "LName");
            return View(selectedTeam);
        }
        [HttpPost]
        public IActionResult Edit(Team team)
        {
            db.Entry(team).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(teams => teams.TeamId == id);
            return View(thisTeam);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(teams => teams.TeamId == id);
            db.Teams.Remove(thisTeam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            ViewBag.DivId = new SelectList(db.Divisions, "DivId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Team newTeam)
        {
            db.Teams.Add(newTeam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

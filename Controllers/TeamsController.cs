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

            var captain = db.Players.FirstOrDefault(players => players.PlayerId == selectTeam.CaptId);

            ViewBag.Captain = captain.FName + " " + captain.LName;
            return View(selectTeam);
        }
    }
}

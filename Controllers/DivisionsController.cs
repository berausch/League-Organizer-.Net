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
    public class DivisionsController : Controller
    {
        private LeagueContext db = new LeagueContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Divisions.ToList());
        }
        public IActionResult Details(int id)
        {
            var thisDivision = db.Divisions
                .Include(divisions => divisions.Teams)
                .FirstOrDefault(divisions => divisions.DivId == id);
            return View(thisDivision);
        }
    }
}

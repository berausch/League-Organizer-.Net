using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueOrganizer.Models
{
    [Table("Divisions")]
    public class Division
    {
        public Division()
        {
            this.Teams = new HashSet<Team>();
        }

        [Key]
        public int DivId { get; set; }
        public string Skill { get; set; }
        public string Name { get; set; }
        public int MaxTeams { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}

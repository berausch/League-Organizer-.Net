using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueOrganizer.Models
{
    [Table("Teams")]
    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
        }

        [Key]
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int DivId { get; set; }
        public int CaptId { get; set; }
        public virtual Division Division { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}

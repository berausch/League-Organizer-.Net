using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueOrganizer.Models
{
    [Table("Players")]
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}

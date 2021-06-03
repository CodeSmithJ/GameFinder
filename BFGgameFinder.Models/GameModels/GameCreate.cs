using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGgameFinder.Models.GameModels
{
    public class GameCreate
    {
        [Required]
        public int GameId { get; set; }
        [Required]
        public string GameName { get; set; }
        [Required]
        public string GameSystem { get; set; }
        [Required]
        public DateTimeOffset ReleaseDate { get; set; }
    }
}

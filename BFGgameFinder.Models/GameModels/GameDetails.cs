using BFGgameFinder.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGgameFinder.Models.GameModels
{
    public class GameDetails
    {
        public int GameId { get; set; }

        [Required]
        public string GameName { get; set; }

        [Required]
        public string Rating { get; set; }
 
        public int? GameSystemId { get; set; }
        public virtual GameSystem GameSystems { get; set; }

        public int? GenreId { get; set; }
        public virtual Genre Genre { get; set; }

    }
}

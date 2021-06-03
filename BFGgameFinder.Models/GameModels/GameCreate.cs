using BFGgameFinder.Data;
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
        public int GameId { get;}

        [Required]
        public string GameName { get; set; }

        [Required]
        public string Rating { get; set; }

        public virtual Genre Genre { get; set; }

        [Required]
        public virtual GameSystem GameSystem { get; set; }
    }
}

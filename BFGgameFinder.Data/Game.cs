using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGgameFinder.Data
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [Required]
        public Guid GamerTag { get; set; }

        [Required]
        public string GameName { get; set; }

        [Required]
        public string Rating { get; set; }

        public DateTimeOffset ReleaseDate { get; set; }

        [ForeignKey(nameof(GameSystem))]
        public int? GameSystemId { get; set; }
        public virtual GameSystem GameSystem { get; set; }

        [ForeignKey(nameof(Genre))]
        public int? GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}

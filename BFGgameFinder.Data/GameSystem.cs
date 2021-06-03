using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGgameFinder.Data
{
    public class GameSystem
    {
        [Key]
        public int GameSystemId { get; set; }

        [Required]
        public string GameSystemType { get; set; }
    }
}
}

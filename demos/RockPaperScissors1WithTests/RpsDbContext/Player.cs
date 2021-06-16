using System;
using System.Collections.Generic;

#nullable disable

namespace RpsDbContext
{
    public partial class Player
    {
        public Player()
        {
            GamePlayer1s = new HashSet<Game>();
            GamePlayer2s = new HashSet<Game>();
        }

        public int PlayerId { get; set; }
        public string PlayerFname { get; set; }
        public string PlayerLname { get; set; }
        public int? PlayerAge { get; set; }

        public virtual ICollection<Game> GamePlayer1s { get; set; }
        public virtual ICollection<Game> GamePlayer2s { get; set; }
    }
}

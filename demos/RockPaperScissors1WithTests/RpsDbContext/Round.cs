using System;
using System.Collections.Generic;

#nullable disable

namespace RpsDbContext
{
    public partial class Round
    {
        public Round()
        {
            GameRound1s = new HashSet<Game>();
            GameRound2s = new HashSet<Game>();
            GameRound3s = new HashSet<Game>();
        }

        public int RoundId { get; set; }
        public int Player1Choice { get; set; }
        public int Player2Choice { get; set; }

        public virtual ICollection<Game> GameRound1s { get; set; }
        public virtual ICollection<Game> GameRound2s { get; set; }
        public virtual ICollection<Game> GameRound3s { get; set; }
    }
}

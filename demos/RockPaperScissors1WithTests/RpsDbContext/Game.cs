using System;
using System.Collections.Generic;

#nullable disable

namespace RpsDbContext
{
    public partial class Game
    {
        public int GameId { get; set; }
        public int? Player1Id { get; set; }
        public int? Player2Id { get; set; }
        public int? Round1Id { get; set; }
        public int? Round2Id { get; set; }
        public int? Round3Id { get; set; }

        public virtual Player Player1 { get; set; }
        public virtual Player Player2 { get; set; }
        public virtual Round Round1 { get; set; }
        public virtual Round Round2 { get; set; }
        public virtual Round Round3 { get; set; }
    }
}

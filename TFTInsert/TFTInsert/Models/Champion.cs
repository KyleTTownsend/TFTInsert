using System;
using System.Collections.Generic;

namespace TFTInsert.Models
{
    public partial class Champion
    {
        public Champion()
        {
            Ability = new HashSet<Ability>();
            ChampionStat = new HashSet<ChampionStat>();
        }

        public int ChampionId { get; set; }
        public string Name { get; set; }
        public int? OriginId { get; set; }
        public int? ClassId { get; set; }
        public short? Cost { get; set; }
        public int? ChampionStatsId { get; set; }

        public ICollection<Ability> Ability { get; set; }
        public ICollection<ChampionStat> ChampionStat { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace TFTInsert.DataModels
{
    public partial class ChampionStat
    {
        public int StatId { get; set; }
        public int? ChampionId { get; set; }
        public short? Damage { get; set; }
        public double? AttackSpeed { get; set; }
        public short? Dps { get; set; }
        public short? Range { get; set; }
        public short? Health { get; set; }
        public short? Armor { get; set; }
        public short? MagicResist { get; set; }

        public Champion Champion { get; set; }
    }
}

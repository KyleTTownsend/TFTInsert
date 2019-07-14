using System;
using System.Collections.Generic;

namespace TFTInsert.DataModels
{
    public partial class Ability
    {
        public Ability()
        {
            AbilityStat = new HashSet<AbilityStat>();
        }

        public int AbilityId { get; set; }
        public int ChampionId { get; set; }
        public string Name { get; set; }
        public string AbilityDesc { get; set; }
        public string AbilityType { get; set; }
        public short? ManaCost { get; set; }
        public short? ManaStart { get; set; }

        public Champion Champion { get; set; }
        public ICollection<AbilityStat> AbilityStat { get; set; }
    }
}

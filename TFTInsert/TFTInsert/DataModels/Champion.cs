using System;
using System.Collections.Generic;

namespace TFTInsert.DataModels
{
    public partial class Champion
    {
        public Champion()
        {
            Ability = new HashSet<Ability>();
            ChampionClassLink = new HashSet<ChampionClassLink>();
            ChampionOriginLink = new HashSet<ChampionOriginLink>();
            ChampionStat = new HashSet<ChampionStat>();
        }

        public int ChampionId { get; set; }
        public string Name { get; set; }
        public short? Cost { get; set; }

        public ICollection<Ability> Ability { get; set; }
        public ICollection<ChampionClassLink> ChampionClassLink { get; set; }
        public ICollection<ChampionOriginLink> ChampionOriginLink { get; set; }
        public ICollection<ChampionStat> ChampionStat { get; set; }
    }
}

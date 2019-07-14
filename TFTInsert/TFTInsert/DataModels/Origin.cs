using System;
using System.Collections.Generic;

namespace TFTInsert.DataModels
{
    public partial class Origin
    {
        public Origin()
        {
            ChampionOriginLink = new HashSet<ChampionOriginLink>();
            OriginBonus = new HashSet<OriginBonus>();
        }

        public int OriginId { get; set; }
        public string Name { get; set; }
        public string OriginDesc { get; set; }
        public int? ImdId { get; set; }

        public ICollection<ChampionOriginLink> ChampionOriginLink { get; set; }
        public ICollection<OriginBonus> OriginBonus { get; set; }
    }
}

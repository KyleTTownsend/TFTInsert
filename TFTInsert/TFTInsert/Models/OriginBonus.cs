using System;
using System.Collections.Generic;

namespace TFTInsert.Models
{
    public partial class OriginBonus
    {
        public OriginBonus()
        {
            OriginBonusLink = new HashSet<OriginBonusLink>();
        }

        public int OriginBonusId { get; set; }
        public short? Needed { get; set; }
        public string Effect { get; set; }

        public ICollection<OriginBonusLink> OriginBonusLink { get; set; }
    }
}

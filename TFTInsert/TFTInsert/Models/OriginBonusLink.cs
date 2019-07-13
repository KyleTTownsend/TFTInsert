using System;
using System.Collections.Generic;

namespace TFTInsert.Models
{
    public partial class OriginBonusLink
    {
        public int OriginId { get; set; }
        public int OriginBonusId { get; set; }

        public Origin Origin { get; set; }
        public OriginBonus OriginBonus { get; set; }
    }
}

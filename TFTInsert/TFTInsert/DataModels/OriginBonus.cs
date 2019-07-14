using System;
using System.Collections.Generic;

namespace TFTInsert.DataModels
{
    public partial class OriginBonus
    {
        public int OriginBonusId { get; set; }
        public int? OriginId { get; set; }
        public short? Needed { get; set; }
        public string Effect { get; set; }

        public Origin Origin { get; set; }
    }
}

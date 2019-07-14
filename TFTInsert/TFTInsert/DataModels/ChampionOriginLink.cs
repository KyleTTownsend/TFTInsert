using System;
using System.Collections.Generic;

namespace TFTInsert.DataModels
{
    public partial class ChampionOriginLink
    {
        public int ChampionId { get; set; }
        public int OriginId { get; set; }

        public Champion Champion { get; set; }
        public Origin Origin { get; set; }
    }
}

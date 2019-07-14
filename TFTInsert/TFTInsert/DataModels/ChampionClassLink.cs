using System;
using System.Collections.Generic;

namespace TFTInsert.DataModels
{
    public partial class ChampionClassLink
    {
        public int ChampionId { get; set; }
        public int ClassId { get; set; }

        public Champion Champion { get; set; }
        public Class Class { get; set; }
    }
}

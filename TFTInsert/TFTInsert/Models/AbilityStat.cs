using System;
using System.Collections.Generic;

namespace TFTInsert.Models
{
    public partial class AbilityStat
    {
        public int AbilityStatId { get; set; }
        public int AbilityId { get; set; }
        public string StatType { get; set; }
        public string StatValue { get; set; }

        public Ability Ability { get; set; }
    }
}

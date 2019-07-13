using System;
using System.Collections.Generic;

namespace TFTInsert.Models
{
    public partial class ClassBonusLink
    {
        public int ClassId { get; set; }
        public int ClassBonusId { get; set; }

        public Class Class { get; set; }
        public ClassBonus ClassBonus { get; set; }
    }
}

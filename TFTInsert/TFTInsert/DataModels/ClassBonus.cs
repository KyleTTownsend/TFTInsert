using System;
using System.Collections.Generic;

namespace TFTInsert.DataModels
{
    public partial class ClassBonus
    {
        public int ClassBonusId { get; set; }
        public string Needed { get; set; }
        public string Effect { get; set; }
        public int? ClassId { get; set; }

        public Class Class { get; set; }
    }
}

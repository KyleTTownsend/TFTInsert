using System;
using System.Collections.Generic;

namespace TFTInsert.Models
{
    public partial class ClassBonus
    {
        public ClassBonus()
        {
            ClassBonusLink = new HashSet<ClassBonusLink>();
        }

        public int ClassBonusId { get; set; }
        public string Needed { get; set; }
        public string Effect { get; set; }

        public ICollection<ClassBonusLink> ClassBonusLink { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace TFTInsert.Models
{
    public partial class Class
    {
        public Class()
        {
            ClassBonusLink = new HashSet<ClassBonusLink>();
        }

        public int ClassId { get; set; }
        public string Name { get; set; }
        public string ClassDesc { get; set; }
        public int? ImgId { get; set; }

        public ICollection<ClassBonusLink> ClassBonusLink { get; set; }
    }
}

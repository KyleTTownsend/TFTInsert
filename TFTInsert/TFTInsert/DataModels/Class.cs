using System;
using System.Collections.Generic;

namespace TFTInsert.DataModels
{
    public partial class Class
    {
        public Class()
        {
            ChampionClassLink = new HashSet<ChampionClassLink>();
            ClassBonus = new HashSet<ClassBonus>();
        }

        public int ClassId { get; set; }
        public string Name { get; set; }
        public string ClassDesc { get; set; }
        public int? ImgId { get; set; }

        public ICollection<ChampionClassLink> ChampionClassLink { get; set; }
        public ICollection<ClassBonus> ClassBonus { get; set; }
    }
}

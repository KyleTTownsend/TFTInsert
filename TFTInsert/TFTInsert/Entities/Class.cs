using System;
using System.Collections.Generic;
using System.Text;

namespace TFTInsert.Entities
{
    public class tftClasses
    {
        public tftClass blademaster { get; set; }
        public tftClass brawler { get; set; }
        public tftClass elementalist { get; set; }
        public tftClass guardian { get; set; }
        public tftClass gunslinger { get; set; }
        public tftClass knight { get; set; }
        public tftClass ranger { get; set; }
        public tftClass shapeshifter { get; set; }
        public tftClass sorcerer { get; set; }
    }
    public class tftClass
    {
        public string key { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string accentChampionImage { get; set; }
        public List<classBonus> bonuses { get; set; }
    }
    public class classBonus
    {
        public string needed { get; set; }
        public string effect { get; set; }
    }
}

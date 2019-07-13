using System;
using System.Collections.Generic;
using System.Text;

namespace TFTInsert
{

    class tftOrigins
    {
        public origin demon { get; set; }
        public origin dragon { get; set; }
        public origin exile { get; set; }
        public origin glacial { get; set; }
        public origin imperial { get; set; }
        public origin noble { get; set; }
        public origin ninja { get; set; }
        public origin pirate { get; set; }
        public origin phantom { get; set; }
        public origin robot { get; set; }
        public origin voidlings { get; set; }
        public origin wild { get; set; }
        public origin yordle { get; set; }
    }
    class origin
    {
        public string key { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string accentChampionImage { get; set; }
        public List<originBonus> bonuses { get; set; }
    }   

    class originBonus
    {
        public short needed { get; set; }
        public string effect { get; set; }
    }
}

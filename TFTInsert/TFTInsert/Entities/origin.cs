using System;
using System.Collections.Generic;
using System.Text;

namespace TFTInsert.Entities
{

    class tftOrigins
    {
        public Origin demon { get; set; }
        public Origin dragon { get; set; }
        public Origin exile { get; set; }
        public Origin glacial { get; set; }
        public Origin imperial { get; set; }
        public Origin noble { get; set; }
        public Origin ninja { get; set; }
        public Origin pirate { get; set; }
        public Origin phantom { get; set; }
        public Origin robot { get; set; }
        public Origin voidlings { get; set; }
        public Origin wild { get; set; }
        public Origin yordle { get; set; }
    }
    class Origin
    {
        public string key { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string accentChampionImage { get; set; }
        public List<OriginBonus> bonuses { get; set; }
    }   

    class OriginBonus
    {
        public short needed { get; set; }
        public string effect { get; set; }
    }
}

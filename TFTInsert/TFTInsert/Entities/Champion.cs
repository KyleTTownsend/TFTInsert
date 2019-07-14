using System;
using System.Collections.Generic;
using System.Text;

namespace TFTInsert.Entities
{
    class champions
    {
        public champion Aatrox { get; set; }
        public champion Ahri { get; set; }
        public champion Akali { get; set; }
        public champion Anivia { get; set; }
        public champion Ashe { get; set; }
        public champion AurelionSol { get; set; }
        public champion Blitzcrank { get; set; }
        public champion Brand { get; set; }
        public champion Braum { get; set; }
        public champion Chogath { get; set; }
        public champion Darius { get; set; }
        public champion Draven { get; set; }
        public champion Elise { get; set; }
        public champion Evelynn { get; set; }
        public champion Fiora { get; set; }
        public champion Gangplank { get; set; }
        public champion Garen { get; set; }
        public champion Gnar { get; set; }
        public champion Graves { get; set; }
        public champion Karthus { get; set; }
        public champion Kassadin { get; set; }
        public champion Katarina { get; set; }
        public champion Kayle { get; set; }
        public champion Kennen { get; set; }
        public champion Khazix { get; set; }
        public champion Kindred { get; set; }
        public champion Leona { get; set; }
        public champion Lissandra { get; set; }
        public champion Lucian { get; set; }
        public champion Lulu { get; set; }
        public champion MissFortune { get; set; }
        public champion Mordekaiser { get; set; }
        public champion Morgana { get; set; }
        public champion Nidalee { get; set; }
        public champion Poppy { get; set; }
        public champion Pyke { get; set; }
        public champion RekSai { get; set; }
        public champion Rengar { get; set; }
        public champion Sejuani { get; set; }
        public champion Shen { get; set; }
        public champion Shyvana { get; set; }
        public champion Swain { get; set; }
        public champion Tristana { get; set; }
        public champion Varus { get; set; }
        public champion Vayne { get; set; }
        public champion Veigar { get; set; }
        public champion Volibear { get; set; }
        public champion Warwick { get; set; }
        public champion Yasuo { get; set; }
        public champion Zed { get; set; }

    }

    class champion
    {
        public string key { get; set; }
        public string name { get; set; }
        public List<string> origin { get; set; }
        public List<string> tft_class { get; set; }
        public short cost { get; set; }
        public ability ability { get; set; }
        public stat stats { get; set; }
    }

    class ability
    {
        public string name { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public short? manaCost { get; set; }
        public short? manaStart { get; set; }
        public List<ability_stat> stats { get; set; }
    }

    class ability_stat
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    class stat
    {
        public offense_stat offense { get; set; }
        public defense_stat defense { get; set; }

    }
    class offense_stat
    {
        public short damage { get; set; }
        public float attackSpeed { get; set; }
        public short dps { get; set; }
        public short range { get; set; }
    }
    class defense_stat
    {
        public short health { get; set; }
        public short armor { get; set; }
        public short magicResist { get; set; }
    }
}

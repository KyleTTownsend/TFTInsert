using System;
using System.Collections.Generic;
using System.Text;

namespace TFTInsert.Entities
{
    public class tftItems
    {
        public ItemComponent bfsword { get; set; }
        public ItemComponent needlesslylargerod { get; set; }
        public ItemComponent recurvebow { get; set; }
        public ItemComponent chainvest { get; set; }
        public ItemComponent giantsbelt { get; set; }
        public ItemComponent spatula{ get; set; }
        public ItemComponent negatroncloak { get; set; }
        public ItemComponent tearofthegoddess { get; set; }
        public ItemFull forceofnature { get; set; }
        public ItemFull bladeoftheruinedking { get; set; }
        public ItemFull bloodthirster { get; set; }
        public ItemFull cursedblade { get; set; }
        public ItemFull darkin { get; set; }
        public ItemFull dragonsclaw { get; set; }
        public ItemFull frozenheart { get; set; }
        public ItemFull frozenmallet { get; set; }
        public ItemFull guardianangel { get; set; }
        public ItemFull guinsoosrageblade { get; set; }
        public ItemFull hextechgunblade { get; set; }
        public ItemFull hush { get; set; }
        public ItemFull infinityedge { get; set; }
        public ItemFull ionicspark { get; set; }
        public ItemFull knightsvow { get; set; }
        public ItemFull locketoftheironsolari { get; set; }
        public ItemFull ludensecho { get; set; }
        public ItemFull morellonomicon { get; set; }
        public ItemFull phantomdancer { get; set; }
        public ItemFull rabadonsdeathcap { get; set; }
        public ItemFull rapidfirecannon { get; set; }
        public ItemFull redbuff { get; set; }
        public ItemFull redemption { get; set; }
        public ItemFull runaanshurricane { get; set; }
        public ItemFull seraphsembrace { get; set; }
        public ItemFull spearofshojin { get; set; }
        public ItemFull statikkshiv { get; set; }
        public ItemFull swordofthedivine { get; set; }
        public ItemFull swordbreaker { get; set; }
        public ItemFull thornmail { get; set; }
        public ItemFull titanichydra { get; set; }
        public ItemFull warmogsarmor { get; set; }
        public ItemFull youmuusghostblade { get; set; }
        public ItemFull yuumi { get; set; }
        public ItemFull zekesherald { get; set; }
        public ItemFull zephyr { get; set; }
    }
    public class ItemComponent
    {
        public string name { get; set; }
        public string type { get; set; }
        public string bonus { get; set; }
        public short tier { get; set; }
        public short depth { get; set; }
        public List<ItemStat> stats { get; set; }
        public string kind { get; set; }
        public List<string> buildsInto { get; set; }
    }
    public class ItemStat
    {
        public string name { get; set; }
        public string title { get; set; }
        public string amount { get; set; }
    }
    public class ItemFull
    {
        public string name { get; set; }
        public string type { get; set; }
        public string bonus { get; set; }
        public short tier { get; set; }
        public short depth { get; set; }
        public List<string> buildsFrom  { get; set; }
        public string kind { get; set; }
    }
}

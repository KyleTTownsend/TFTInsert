using System;
using System.Collections.Generic;

namespace TFTInsert.Models
{
    public partial class ItemComponent
    {
        public ItemComponent()
        {
            ItemComponentStat = new HashSet<ItemComponentStat>();
            ItemLink = new HashSet<ItemLink>();
        }

        public int ItemComponentId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Bonus { get; set; }
        public short? Tier { get; set; }
        public short? Depth { get; set; }
        public string Kind { get; set; }

        public ICollection<ItemComponentStat> ItemComponentStat { get; set; }
        public ICollection<ItemLink> ItemLink { get; set; }
    }
}

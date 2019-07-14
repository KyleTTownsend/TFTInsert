using System;
using System.Collections.Generic;

namespace TFTInsert.DataModels
{
    public partial class ItemFull
    {
        public ItemFull()
        {
            ItemLink = new HashSet<ItemLink>();
        }

        public int ItemFullId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Bonus { get; set; }
        public short? Tier { get; set; }
        public short? Depth { get; set; }
        public string Kind { get; set; }

        public ICollection<ItemLink> ItemLink { get; set; }
    }
}

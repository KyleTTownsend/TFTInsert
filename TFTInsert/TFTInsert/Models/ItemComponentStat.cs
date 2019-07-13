using System;
using System.Collections.Generic;

namespace TFTInsert.Models
{
    public partial class ItemComponentStat
    {
        public int ItemComponentStatId { get; set; }
        public int ItemComponentId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Amount { get; set; }

        public ItemComponent ItemComponent { get; set; }
    }
}

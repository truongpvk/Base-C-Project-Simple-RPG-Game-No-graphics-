using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Project
{
    public class LootItem
    {
        public Item Details { get; set; }
        public int PercentDropped { get; set; }
        public bool isDefaultItem { get; set; }

        public LootItem() { }

        public LootItem(Item item, int percent, bool isDefaut = false)
        {
            Details = item;
            PercentDropped = percent;
            isDefaultItem = isDefaut;
        }
    }
}

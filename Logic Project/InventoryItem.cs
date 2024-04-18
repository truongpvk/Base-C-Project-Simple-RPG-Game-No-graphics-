using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Project
{
    public class InventoryItem
    {
        public Item Details { get; set; }
        public int Quantity { get; set; }
        public InventoryItem() { }
        public InventoryItem(Item item, int quantity) {
            Details = item;
            Quantity = quantity;
        }
    }
}

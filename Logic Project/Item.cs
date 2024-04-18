using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Project
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }

        public Item() { }
        public Item(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}

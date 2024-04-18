using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Project
{
    public class Potion : Item
    {
        public int amountHeal { get; set; }

        public Potion() { }
        public Potion(int id, string name, int heal) : 
            base (id, name)
        {
            amountHeal = heal;
        }
    }
}

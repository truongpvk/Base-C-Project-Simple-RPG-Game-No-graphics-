using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Project
{
    public class Weapon : Item
    {
        public int minimumDamage { get; set; }
        public int maximumDamage { get; set; }

        public Weapon() { }
        public Weapon(int id, string name, int minimumDamage, int maximumDamage) :
            base (id, name)
        {
            this.minimumDamage = minimumDamage;
            this.maximumDamage = maximumDamage;
        }
    }
}

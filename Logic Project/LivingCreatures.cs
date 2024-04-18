using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Project
{
    public class LivingCreatures
    {
        public int currentHP {  get; set; }
        public int maximumHP { get; set; }

        public LivingCreatures() { }
        public LivingCreatures(int currentHP, int maximumHP)
        {
            this.currentHP = currentHP;
            this.maximumHP = maximumHP;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Project
{
    public class Monster : LivingCreatures
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NamePlural { get; set; }
        public int maxDamage { get; set; }
        public int rewardExp { get; set; }
        public int rewardGold { get; set; }

        public List<LootItem> LootTable { get; set; }
        public Monster() { }
        public Monster(int id, string name, int current_hp, 
                        int max_hp, int damage, int exp, int gold) :
                        base (current_hp, max_hp)
        {
            ID = id;
            Name = name;
            maxDamage = damage;
            rewardExp = exp;
            rewardGold = gold;
            LootTable = new List<LootItem>();
        }
    }
}

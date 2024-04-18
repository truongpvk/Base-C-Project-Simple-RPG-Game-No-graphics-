using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Project
{
    public class Quest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int rewardExp { get; set; }
        public int rewardGold { get; set; }
        public Item RewardItem { get; set; }
        public List<QuestCompleteItem> CompleteItems { get; set; }
        public Quest() { }
        public Quest(int iD, string name, string description, int rewardExp, int rewardGold, Item rewardItem)
        {
            ID = iD;
            Name = name;
            Description = description;
            this.rewardExp = rewardExp;
            this.rewardGold = rewardGold;
            RewardItem = rewardItem;
            CompleteItems = new List<QuestCompleteItem>();
        }
    }
}

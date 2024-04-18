using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Project
{
    public class Player : LivingCreatures
    {
        public int amountGold { get; set; }
        public int amountEXP { get; set; }
        public int currentLevel { get; set; }

        public List<InventoryItem> inventoryItems { get; set; }
        public List<PlayerQuest> playerQuests { get; set; }

        public Location currentLocation { get; set; }
        public Player() { }
        public Player(int current_hp, int max_hp, int gold, int exp, int level) : base(current_hp, max_hp)
        {
            amountGold = gold;
            amountEXP = exp;
            currentLevel = level;
            inventoryItems = new List<InventoryItem>();
            playerQuests = new List<PlayerQuest>();
        }

        public void setLevel()
        {
            currentLevel = amountEXP / 100 + 1;

            IncreseHPperLevel(currentLevel);
        }
        public void IncreseHPperLevel(int newLevel)
        {
            maximumHP = (int) (1.0 * 100 * Math.Pow(1.1, newLevel - 1));
            currentHP = maximumHP;
        } 
        public void AddNewQuest(Quest quest)
        {
            PlayerQuest pq = new PlayerQuest(quest, false);
            playerQuests.Add(pq);
        }
        public void UpdateQuest(int id)
        {
            foreach(PlayerQuest pq in playerQuests)
            {
                if (pq.Details.ID == id)
                {
                    pq.isComplete = true;
                }
            }
        }

        public void CompleteQuest(Quest quest)
        {
            foreach (QuestCompleteItem item in quest.CompleteItems)
            {
                InventoryRemove(item.Details, item.Quantity);
            }
            UpdateQuest(quest.ID);

            amountEXP += quest.rewardExp;
            amountGold += quest.rewardGold;

            InventoryAdd(quest.RewardItem, 1);
        }
        public void InventoryAdd(Item items, int quantity)
        {
            if(ItemByID(items.ID) == null)
            {
                inventoryItems.Add(new InventoryItem(items, quantity));
            } else
            {
                foreach(InventoryItem item in inventoryItems)
                {
                    if(item.Details.ID == items.ID)
                    {
                        item.Quantity += quantity;
                    }
                }
            }
        }
        public void InventoryRemove(Item item, int quantity)
        {

            foreach (InventoryItem ii in inventoryItems)
            {
                if (ii.Details.ID == item.ID)
                {
                    ii.Quantity = quantity <= ii.Quantity ? ii.Quantity - quantity : ii.Quantity;

                    if (ii.Quantity == 0) { inventoryItems.Remove(ii); }
                }
            }

        }
        public Item ItemByID(int id)
        {
            foreach (InventoryItem item in inventoryItems)
            {
                if (item.Details.ID == id) return item.Details;
            }
            return null;
        }
        public PlayerQuest QuestByID(int id)
        {
            foreach (PlayerQuest playerQuest in playerQuests)
            {
                if (playerQuest.Details.ID == id)
                {
                    return playerQuest;
                }
            }
            return null;
        }
    }
}

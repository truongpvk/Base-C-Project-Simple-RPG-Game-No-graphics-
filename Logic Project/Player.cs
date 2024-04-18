using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
        public static Player CreateDefaultPlayer()
        {
            Player player = new Player(100, 100, 50, 0, 1);
            player.inventoryItems.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_IRON_SWORD), 1));
            player.inventoryItems.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_HEALING_POTION), 1));
            player.currentLocation = World.LocationByID(World.LOCATION_ID_HOME);
            return player;
        }
        public static Player CreatePlayerFromXMLString(string xmlPlayerData)
        {
            try
            {
                XmlDocument playerData = new XmlDocument();
                playerData.Load(xmlPlayerData);

                int current_hp =
                    Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/CurrentHitPoints").InnerText);

                int maximum_hp =
                    Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/MaximumHitPoints").InnerText);

                int gold =
                    Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/Gold").InnerText);

                int exp =
                    Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/ExperiencePoints").InnerText);

                int level =
                    Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/Level").InnerText);

                Player player = new Player(current_hp, maximum_hp, gold, exp, level);

                int currentLocationID =
                    Convert.ToInt32(playerData.SelectSingleNode("/Player/Stats/CurrentLocation").InnerText);

                player.currentLocation = World.LocationByID(currentLocationID);

                foreach (XmlNode node in playerData.SelectNodes("/Player/InventoryItems/InventoryItem"))
                {
                    int id = Convert.ToInt32(node.Attributes["ID"].Value);
                    int quantity = Convert.ToInt32(node.Attributes["Quantity"].Value);

                    player.InventoryAdd(World.ItemByID(id), quantity);

                }

                foreach (XmlNode node in playerData.SelectNodes("/Player/PlayerQuests/PlayerQuest"))
                {
                    int id = Convert.ToInt32(node.Attributes["ID"].Value);
                    bool isCompleted = Convert.ToBoolean(node.Attributes["IsCompleted"].Value);
                    PlayerQuest playerQuest = new PlayerQuest(World.QuestByID(id), isCompleted);

                    player.playerQuests.Add(playerQuest);
                }

                return player;
            } catch
            {
                return Player.CreateDefaultPlayer();
            }
        }
        public void setLevel()
        {
            currentLevel = amountEXP / 100 + 1;

            IncreseHPperLevel(currentLevel);
        }
        public void IncreseHPperLevel(int newLevel)
        {
            maximumHP = (int)(1.0 * 100 * Math.Pow(1.1, newLevel - 1));
            currentHP = maximumHP;
        }
        public void AddNewQuest(Quest quest)
        {
            PlayerQuest pq = new PlayerQuest(quest, false);
            playerQuests.Add(pq);
        }
        public void UpdateQuest(int id)
        {
            foreach (PlayerQuest pq in playerQuests)
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
            if (ItemByID(items.ID) == null)
            {
                inventoryItems.Add(new InventoryItem(items, quantity));
            }
            else
            {
                foreach (InventoryItem item in inventoryItems)
                {
                    if (item.Details.ID == items.ID)
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

        public string ToXmlString()
        {
            XmlDocument playerData = new XmlDocument();

            // Create the top-level XML node
            XmlNode player = playerData.CreateElement("Player");
            playerData.AppendChild(player);

            // Create the "Stats" child node to hold the other player statistics nodes
            XmlNode stats = playerData.CreateElement("Stats");
            player.AppendChild(stats);

            // Create the child nodes for the "Stats" node
            XmlNode currentHitPoints = playerData.CreateElement("CurrentHitPoints");
            currentHitPoints.AppendChild(playerData.CreateTextNode(this.currentHP.ToString()));
            stats.AppendChild(currentHitPoints);

            XmlNode maximumHitPoints = playerData.CreateElement("MaximumHitPoints");
            maximumHitPoints.AppendChild(playerData.CreateTextNode(this.maximumHP.ToString()));
            stats.AppendChild(maximumHitPoints);

            XmlNode gold = playerData.CreateElement("Gold");
            gold.AppendChild(playerData.CreateTextNode(this.amountGold.ToString()));
            stats.AppendChild(gold);

            XmlNode experiencePoints = playerData.CreateElement("ExperiencePoints");
            experiencePoints.AppendChild(playerData.CreateTextNode(this.amountEXP.ToString()));
            stats.AppendChild(experiencePoints);

            XmlNode level = playerData.CreateElement("Level");
            level.AppendChild(playerData.CreateTextNode(this.currentLevel.ToString()));
            stats.AppendChild(level);

            XmlNode currentLocation = playerData.CreateElement("CurrentLocation");
            currentLocation.AppendChild(playerData.CreateTextNode(this.currentLocation.ID.ToString()));
            stats.AppendChild(currentLocation);

            // Create the "InventoryItems" child node to hold each InventoryItem node
            XmlNode inventoryItems = playerData.CreateElement("InventoryItems");
            player.AppendChild(inventoryItems);

            // Create an "InventoryItem" node for each item in the player's inventory
            foreach (InventoryItem item in this.inventoryItems)
            {
                XmlNode inventoryItem = playerData.CreateElement("InventoryItem");
                XmlAttribute idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = item.Details.ID.ToString();
                inventoryItem.Attributes.Append(idAttribute);

                XmlAttribute quantityAttribute = playerData.CreateAttribute("Quantity");
                quantityAttribute.Value = item.Quantity.ToString();
                inventoryItem.Attributes.Append(quantityAttribute);
                inventoryItems.AppendChild(inventoryItem);
            }

            // Create the "PlayerQuests" child node to hold each PlayerQuest node
            XmlNode playerQuests = playerData.CreateElement("PlayerQuests");
            player.AppendChild(playerQuests);

            // Create a "PlayerQuest" node for each quest the player has acquired
            foreach (PlayerQuest quest in this.playerQuests)
            {
                XmlNode playerQuest = playerData.CreateElement("PlayerQuest");
                XmlAttribute idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = quest.Details.ID.ToString();
                playerQuest.Attributes.Append(idAttribute);

                XmlAttribute isCompletedAttribute = playerData.CreateAttribute("IsCompleted");
                isCompletedAttribute.Value = quest.isComplete.ToString();
                playerQuest.Attributes.Append(isCompletedAttribute);
                playerQuests.AppendChild(playerQuest);
            }

            return playerData.InnerXml; // The XML document, as a string, so we can save the data to disk
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Logic_Project;

namespace The_RPG_Based
{
    public partial class SuperAdventure : Form
    {
        private Player _player;
        private Monster _currentMonster;
        private Weapon _currentWeapon;
        private Potion _currentPotion;

        private const string PLAYER_DATA_FILE_NAME = "PlayerData.xml";
        public SuperAdventure()
        {
            InitializeComponent();
            if (File.Exists(PLAYER_DATA_FILE_NAME))
            {
                _player = Player.CreatePlayerFromXMLString(File.ReadAllText(PLAYER_DATA_FILE_NAME));
            }
            else
            {
                _player = Player.CreateDefaultPlayer();
            }
            _player.IncreseHPperLevel(_player.currentLevel);

            moveTo(_player.currentLocation);
            ResetAll();
        }


        private void SuperAdventure_Load(object sender, EventArgs e)
        {

        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            moveTo(_player.currentLocation.LocationToNorth);
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            moveTo(_player.currentLocation.LocationToWest);
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            moveTo(_player.currentLocation.LocationToEast);
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            moveTo(_player.currentLocation.LocationToSouth);
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {
            //Get currently weapon from cbo
            _currentWeapon = (Weapon)cboWeapon.SelectedItem;
            //Determine damage of player
            int damageToMonster = Logic_Project.RandomNumberGenerator.NumberBetween(_currentWeapon.minimumDamage, _currentWeapon.maximumDamage);
            //Apply damage to monster's HP
            _currentMonster.currentHP -= damageToMonster;
            rtbMessage.Text = "You deal " + damageToMonster + " damage to " + _currentMonster.Name + Environment.NewLine;
            rtbMessage.Text += "It remains " + (_currentMonster.currentHP < 0 ? "0" : _currentMonster.currentHP) + Environment.NewLine;
            //If monster dead (HP = 0)
            if (_currentMonster.currentHP <= 0)
            {
                //Message
                rtbMessage.Text += _currentMonster.Name + "dead!" + Environment.NewLine;
                //Give player exp, gold and item
                _player.amountGold += _currentMonster.rewardGold;
                _player.amountEXP += _currentMonster.rewardExp;
                List<InventoryItem> lootedItem = new List<InventoryItem>();

                foreach (LootItem li in _currentMonster.LootTable)
                {
                    if (Logic_Project.RandomNumberGenerator.NumberBetween(1, 100) <= li.PercentDropped)
                    {
                        lootedItem.Add(new InventoryItem(li.Details, 1));
                    }
                }
                if (lootedItem.Count == 0)
                {
                    rtbMessage.Text += "You don't loot anything, try again!" + Environment.NewLine;
                }
                else
                    foreach (InventoryItem li in lootedItem)
                    {
                        _player.InventoryAdd(li.Details, li.Quantity);
                        rtbMessage.Text += "You loot " + li.Details.Name + Environment.NewLine;
                    }

                //Spawn new monster
                IsHereHasMonster(_player.currentLocation);
            }
            //If monster alive
            else
            {
                //How much damage monster deal to player
                int damageToPlayer = _currentMonster.maxDamage;
                //Message
                rtbMessage.Text += "You take " + damageToPlayer.ToString() + " from " + _currentMonster.Name + Environment.NewLine;
                //Apply to Player's HP
                _player.currentHP -= damageToPlayer;
                rtbMessage.Text += "You remain " + _player.currentHP.ToString() + Environment.NewLine;

                ResetPlayerStatusUI();
                //If player dead
                if (_player.currentHP == 0)
                {
                    //Move to home, reduce HP
                    moveTo(World.LocationByID(World.LOCATION_ID_HOME));
                    _player.currentHP = _player.maximumHP;
                    rtbMessage.Text += "You died!" + Environment.NewLine;
                }

            }
            ResetAll();


        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {
            _currentPotion = (Potion)cboPotions.SelectedItem;
            if (_currentPotion == null)
            {
                rtbMessage.Text = "You don't have this potion, please choose another!" + Environment.NewLine;
            }
            else if (_player.currentHP == _player.maximumHP)
            {
                rtbMessage.Text += "You don't need healing right now!" + Environment.NewLine;
            }
            else
            {
                _player.currentHP += _currentPotion.amountHeal;
                if (_player.currentHP > _player.maximumHP) { _player.currentHP = _player.maximumHP; }
                _player.InventoryRemove(World.ItemByID(World.ITEM_ID_HEALING_POTION), 1);
                rtbMessage.Text += "You was healed " + _currentPotion.amountHeal + Environment.NewLine;
            }
            ResetAll();
        }

        private void moveTo(Location newLocation)
        {
            rtbMessage.Clear();
            if (newLocation.ItemRequired != null)
            {
                if (_player.ItemByID(newLocation.ItemRequired.ID) == null)
                {
                    rtbMessage.Text += "You don't have " + newLocation.ItemRequired.Name +
                                            " to move to " + newLocation.Name + "." + Environment.NewLine;
                    return;
                }
            }

            _player.currentLocation = newLocation;

            btnNorth.Visible = newLocation.LocationToNorth != null;
            btnSouth.Visible = newLocation.LocationToSouth != null;
            btnWest.Visible = newLocation.LocationToWest != null;
            btnEast.Visible = newLocation.LocationToEast != null;

            rtbLocation.Text = newLocation.Name + Environment.NewLine;
            rtbLocation.Text += newLocation.Descrition + Environment.NewLine;

            _player.currentHP = _player.maximumHP;

            lbHitPoint.Text = _player.currentHP.ToString();

            //Do this location have quest?
            IsHereHasQuest(newLocation);

            //Does the location have monster
            IsHereHasMonster(newLocation);

            //Reset List in UI
            ResetInventoryListUI();
            ResetQuestUI();
            ResetWeaponCBOinUI();
            ResetPotionCBOinUI();

        }

        //Check Quest in new location
        private void IsHereHasQuest(Location location)
        {
            //Here has Quest?
            if (location.QuestAvaiable != null)
            {
                //Player already has this quest?
                bool PlayerAlreadyCompletedQuest = false;
                PlayerQuest PlayerAlreadyHasQuest = _player.QuestByID(location.QuestAvaiable.ID);
                if (PlayerAlreadyHasQuest != null)
                {
                    PlayerAlreadyCompletedQuest = PlayerAlreadyHasQuest.isComplete;
                }
                else
                {
                    _player.AddNewQuest(location.QuestAvaiable);
                    return;
                }

                //Player not complete this quest?
                if (!PlayerAlreadyCompletedQuest)
                {
                    //Player has the item for this quest?
                    bool PlayerCanCompletedRightNow =
                        PlayerCanCompleteQuest(PlayerAlreadyHasQuest);
                    //If so, reset the inventory
                    if (PlayerCanCompletedRightNow)
                    {
                        _player.CompleteQuest(location.QuestAvaiable);

                        lbGold.Text = _player.amountGold.ToString();
                        lbExperience.Text = _player.amountEXP.ToString();
                        rtbMessage.Text += "You complete " + location.QuestAvaiable.Name + Environment.NewLine;
                    }
                }
            }

        }
        private bool PlayerCanCompleteQuest(PlayerQuest playerQuest)
        {
            List<bool> isDone = new List<bool>();
            foreach (QuestCompleteItem qci in playerQuest.Details.CompleteItems)
            {
                foreach (InventoryItem ii in _player.inventoryItems)
                {
                    if (ii.Details.ID == qci.Details.ID && ii.Quantity >= qci.Quantity)
                    {
                        isDone.Add(true);
                    }
                }
            }
            if (playerQuest.Details.CompleteItems.Count == 0) { return true; }
            if (isDone.Count != playerQuest.Details.CompleteItems.Count) { return false; }
            return true;
        }
        //Check monster in new location
        private void IsHereHasMonster(Location newLocation)
        {
            if (newLocation.MonsterLivingHere != null)
            {
                rtbMessage.Text += "You can see " + newLocation.MonsterLivingHere.Name + " living here." + Environment.NewLine;
                Monster spawnMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);

                _currentMonster = spawnMonster;
                _currentMonster.currentHP = _currentMonster.maximumHP;
                cboWeapon.Visible = true;
                cboPotions.Visible = true;
                btnUseWeapon.Visible = true;
                btnUsePotion.Visible = true;
            }
            else
            {
                _currentMonster = null;

                cboWeapon.Visible = false;
                cboPotions.Visible = false;
                btnUseWeapon.Visible = false;
                btnUsePotion.Visible = false;
            }
        }
        //Reset windows form
        private void ResetInventoryListUI()
        {
            // Refresh player's inventory list
            dgvInventory.RowHeadersVisible = false;

            dgvInventory.ColumnCount = 2;
            dgvInventory.Columns[0].Name = "Name";
            dgvInventory.Columns[0].Width = 197;
            dgvInventory.Columns[1].Name = "Quantity";

            dgvInventory.Rows.Clear();

            foreach (InventoryItem inventoryItem in _player.inventoryItems)
            {
                if (inventoryItem.Quantity > 0)
                {
                    dgvInventory.Rows.Add(new[] { inventoryItem.Details.Name, inventoryItem.Quantity.ToString() });
                }
            }
        }
        private void ResetQuestUI()
        {
            dgvQuests.RowHeadersVisible = false;

            dgvQuests.ColumnCount = 2;
            dgvQuests.Columns[0].Name = "Name";
            dgvQuests.Columns[0].Width = 197;
            dgvQuests.Columns[1].Name = "Done?";

            dgvQuests.Rows.Clear();

            foreach (PlayerQuest playerQuest in _player.playerQuests)
            {
                dgvQuests.Rows.Add(new[] { playerQuest.Details.Name, playerQuest.isComplete.ToString() });
            }
        }
        private void ResetWeaponCBOinUI()
        {
            List<Weapon> weapons = new List<Weapon>();

            foreach (InventoryItem inventoryItem in _player.inventoryItems)
            {
                if (inventoryItem.Details is Weapon)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        weapons.Add((Weapon)inventoryItem.Details);
                    }
                }
            }

            if (weapons.Count == 0)
            {
                // The player doesn't have any weapons, so hide the weapon combobox and "Use" button
                cboWeapon.Visible = false;
                btnUseWeapon.Visible = false;
            }
            else
            {
                cboWeapon.DataSource = weapons;
                cboWeapon.DisplayMember = "Name";
                cboWeapon.ValueMember = "ID";

                cboWeapon.SelectedIndex = 0;
            }
        }
        private void ResetPotionCBOinUI()
        {
            List<Potion> healingPotions = new List<Potion>();

            foreach (InventoryItem inventoryItem in _player.inventoryItems)
            {
                if (inventoryItem.Details is Potion)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        healingPotions.Add((Potion)inventoryItem.Details);
                    }
                }
            }

            if (healingPotions.Count == 0)
            {
                // The player doesn't have any potions, so hide the potion combobox and "Use" button
                cboPotions.Visible = false;
                btnUsePotion.Visible = false;
            }
            else
            {
                cboPotions.DataSource = healingPotions;
                cboPotions.DisplayMember = "Name";
                cboPotions.ValueMember = "ID";

                cboPotions.SelectedIndex = 0;
            }
        }

        private void ResetPlayerStatusUI()
        {
            lbHitPoint.Text = _player.currentHP.ToString();
            lbGold.Text = _player.amountGold.ToString();
            lbExperience.Text = _player.amountEXP.ToString();
            lbLevel.Text = _player.currentLevel.ToString();
        }
        private void ResetAll()
        {
            ResetInventoryListUI();
            ResetPlayerStatusUI();
            ResetQuestUI();
            ResetPotionCBOinUI();
            ResetWeaponCBOinUI();
        }

        private void lbExperience_TextChanged(object sender, EventArgs e)
        {
            _player.setLevel();
            ResetAll();
        }

        private void SuperAdventure_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(PLAYER_DATA_FILE_NAME, _player.ToXmlString());
        }
    }

}

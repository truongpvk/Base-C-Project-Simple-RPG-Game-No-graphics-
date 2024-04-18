using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Project
{
    public static class World
    {
        public static readonly List<Location> Locations = new List<Location>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Quest> Quests = new List<Quest>();

        //Create ID of Location, Monster, Item and Quest
        //Item
        public const int ITEM_ID_BLACK_SKELETON = 1;
        public const int ITEM_ID_OLD_CLOCK = 2;
        public const int ITEM_ID_DRAGON_EYES = 3;
        public const int ITEM_ID_ANCIENT_SCROLL = 4;
        public const int ITEM_ID_SHIELD_OF_THE_SAINT = 5;
        public const int ITEM_ID_IRON_SWORD = 6;
        public const int ITEM_ID_STEEL_SWORD = 7;
        public const int ITEM_ID_RUBY_SWORD = 8;
        public const int ITEM_ID_DEATH_SCYTHE = 9;
        public const int ITEM_ID_WAND_OF_LEGEND = 10;
        public const int ITEM_ID_HEALING_POTION = 11;

        //Monster
        public const int MONSTER_ID_PIGGY = 1;
        public const int MONSTER_ID_SNAKE = 2;
        public const int MONSTER_ID_MINOTAUR = 3;
        public const int MONSTER_ID_FALLEN_ANGEL = 4;
        public const int MONSTER_ID_GREAT_FALLEN_ANGEL = 5;
        public const int MONSTER_ID_DEMON_KING = 6;

        //Location
        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_GOLEM_FOREST = 2;
        public const int LOCATION_ID_GOLDEN_FOREST = 3;
        public const int LOCATION_ID_ABYSS = 3;
        public const int LOCATION_ID_SKY_REALM = 4;
        public const int LOCATION_ID_DEMON_CASTLE = 5;
        public const int LOCATION_ID_CAVE_OF_DRAGON = 6;
        public const int LOCATION_ID_SEA_OF_STAR = 7;
        public const int LOCATION_ID_BLACK_MOUNTAIN = 8;
        public const int LOCATION_ID_ARIS_RIVER = 9;

        //Quest
        public const int QUEST_ID_KILL_PIGGY = 1;
        public const int QUEST_ID_KILL_SNAKE = 2;
        public const int QUEST_ID_KILL_MINOTAUR = 3;
        public const int QUEST_ID_KILL_FALLEN_ANGEL = 4;
        public const int QUEST_ID_KILL_GREAT_FALLEN_ANGEL = 5;
        public const int QUEST_ID_KILL_DEMON_KING = 6;
        public const int QUEST_ID_GO_TO_SKY_REALM = 7;
        public const int QUEST_ID_MEET_AN_DRAGON = 8;
        public const int QUEST_ID_HELP_FOR_DRAGON = 9;
        public const int QUEST_ID_TAKE_STARS = 10;

        static World()
        {
            PopulateItem();
            PopulateMonster();
            PopulateLocation();
            PopulateQuest();   
        }

        static void PopulateItem()
        {
            Items.Add(new Item(ITEM_ID_BLACK_SKELETON, "Black Skeleton"));
            Items.Add(new Item(ITEM_ID_OLD_CLOCK, "Old Clock"));
            Items.Add(new Item(ITEM_ID_DRAGON_EYES, "Dragon Eyes"));
            Items.Add(new Item(ITEM_ID_ANCIENT_SCROLL, "Ancient Scroll"));
            Items.Add(new Item(ITEM_ID_SHIELD_OF_THE_SAINT, "Shield of the Saint"));
            Items.Add(new Weapon(ITEM_ID_IRON_SWORD, "Iron Sword", 10, 25));
            Items.Add(new Weapon(ITEM_ID_STEEL_SWORD, "Steel Sword", 25, 75));
            Items.Add(new Weapon(ITEM_ID_RUBY_SWORD, "Ruby Sword", 80, 150));
            Items.Add(new Weapon(ITEM_ID_DEATH_SCYTHE, "Death Scythe", 100, 250));
            Items.Add(new Weapon(ITEM_ID_WAND_OF_LEGEND, "Wand of Legend", 300, 450));
            Items.Add(new Potion(ITEM_ID_HEALING_POTION, "Healing Potion", 100));
        }

        static void PopulateMonster()
        {
            Monster piggy = new Monster(MONSTER_ID_PIGGY, "Piggy", 100, 100, 20, 10, 5);
            piggy.LootTable.Add(new LootItem(ItemByID(ITEM_ID_IRON_SWORD), 25, false));
            piggy.LootTable.Add(new LootItem(ItemByID(ITEM_ID_HEALING_POTION), 100, true));

            Monster snake = new Monster(MONSTER_ID_SNAKE, "Snake", 150, 150, 25, 20, 8);
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_STEEL_SWORD), 25, false));
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_DRAGON_EYES), 5, false));
            snake.LootTable.Add(new LootItem(ItemByID(ITEM_ID_OLD_CLOCK), 10, false));

            Monster minotaur = new Monster(MONSTER_ID_MINOTAUR, "Minotaur", 300, 300, 45, 25, 15);
            minotaur.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RUBY_SWORD), 15, false));
            minotaur.LootTable.Add(new LootItem(ItemByID(ITEM_ID_ANCIENT_SCROLL), 100, true));
            minotaur.LootTable.Add(new LootItem(ItemByID(ITEM_ID_BLACK_SKELETON), 30, false));


            Monster fallen_angel = new Monster(MONSTER_ID_FALLEN_ANGEL, "Fallen Angel", 500, 500, 100, 50, 25);
            fallen_angel.LootTable.Add(new LootItem(ItemByID(ITEM_ID_ANCIENT_SCROLL), 100, true));
            fallen_angel.LootTable.Add(new LootItem(ItemByID(ITEM_ID_RUBY_SWORD), 30, false));
            fallen_angel.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SHIELD_OF_THE_SAINT), 5, false));
            fallen_angel.LootTable.Add(new LootItem(ItemByID(ITEM_ID_DRAGON_EYES), 10, false));
            
            Monster great_fallen_angel = new Monster(MONSTER_ID_GREAT_FALLEN_ANGEL, "Great Fallen Angel", 1500, 1500, 150, 100, 75);
            great_fallen_angel.LootTable.Add(new LootItem(ItemByID(ITEM_ID_ANCIENT_SCROLL), 100, true));
            great_fallen_angel.LootTable.Add(new LootItem(ItemByID(ITEM_ID_DEATH_SCYTHE), 15, false));
            great_fallen_angel.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SHIELD_OF_THE_SAINT), 15, false));
            great_fallen_angel.LootTable.Add(new LootItem(ItemByID(ITEM_ID_WAND_OF_LEGEND), 1, false)); 

            Monster demon_king = new Monster(MONSTER_ID_DEMON_KING, "Demon King", 5000, 5000, 500, 1000, 1000);
            demon_king.LootTable.Add(new LootItem(ItemByID(ITEM_ID_WAND_OF_LEGEND), 100, true));

            Monsters.Add(piggy);
            Monsters.Add(snake);
            Monsters.Add(minotaur);
            Monsters.Add(fallen_angel);
            Monsters.Add(great_fallen_angel);
            Monsters.Add(demon_king);
        
        }

        static void PopulateQuest()
        {
            Quest piggy = new Quest(QUEST_ID_KILL_PIGGY,"Kill Piggy" ,"Kill 10 piggy!", 100, 100, ItemByID(ITEM_ID_BLACK_SKELETON));
            Quest snake = new Quest(QUEST_ID_KILL_SNAKE, "Kill Snake","Kill 20 snake", 200, 200, ItemByID(ITEM_ID_STEEL_SWORD));
            Quest minotaur = new Quest(QUEST_ID_KILL_MINOTAUR, "Kill Minotaur","Kill 30 minotaur" , 350, 350, ItemByID(ITEM_ID_OLD_CLOCK));
            Quest fallen_angel = new Quest(QUEST_ID_KILL_FALLEN_ANGEL, "Kill Fallen Angel","Kill 50 fallen angel", 700, 700, ItemByID(ITEM_ID_DRAGON_EYES));
            Quest great_fallen_angel = new Quest(QUEST_ID_KILL_GREAT_FALLEN_ANGEL, "Kill Great Fallen Angel","Kill 100 great fallen angel", 1500, 1500, ItemByID(ITEM_ID_RUBY_SWORD));
            Quest demon_king = new Quest(QUEST_ID_KILL_DEMON_KING, "Kill Demon King!","Kill Demon King! Over!", 100000, 100000, ItemByID(ITEM_ID_WAND_OF_LEGEND));
            Quest go_sky_realm = new Quest(QUEST_ID_GO_TO_SKY_REALM, "Look the sky!","Go to Sky Realm to take a scroll", 1000, 1500, ItemByID(ITEM_ID_ANCIENT_SCROLL));
            Quest meet_dragon = new Quest(QUEST_ID_MEET_AN_DRAGON, "Dragon is real!","Meet a elder dragon, he need some help!", 650, 1000, ItemByID(ITEM_ID_DRAGON_EYES));
            Quest help_dragon = new Quest(QUEST_ID_HELP_FOR_DRAGON, "A help for you!","Go to Black Moutain and Kill 1000 Angel", 10000, 2000, ItemByID(ITEM_ID_DEATH_SCYTHE));
            Quest take_star = new Quest(QUEST_ID_TAKE_STARS, "Do you see this light?","Go to Sea of Star to take some star light, give it to the elder dragon", 10000, 10000, ItemByID(ITEM_ID_OLD_CLOCK));
            Quests.Add(piggy);
            Quests.Add(snake);
            Quests.Add(minotaur);
            Quests.Add(fallen_angel);
            Quests.Add(great_fallen_angel);
            Quests.Add(demon_king);
            Quests.Add(go_sky_realm);
            Quests.Add(meet_dragon);
            Quests.Add(help_dragon);
            Quests.Add(take_star);
        }

        static void PopulateLocation()
        {
            //Set location
            Location home = new Location(LOCATION_ID_HOME, "Home", "Where you start your journey.");

            Location golem_forest = new Location(LOCATION_ID_GOLEM_FOREST, 
                                    "Golem Forest", 
                                    "Legend has it that this place is the homeland of the powerful Golem species, but they suddenly disappeared without a trace...", 
                                    ItemByID(ITEM_ID_IRON_SWORD), QuestByID(QUEST_ID_KILL_PIGGY), 
                                    MonsterByID(MONSTER_ID_PIGGY));

            Location golden_forest = new Location(LOCATION_ID_GOLDEN_FOREST, "Golden Forest",
                                    "Golden leaves grow everywhere here, but they are not real gold!", 
                                    null, QuestByID(QUEST_ID_GO_TO_SKY_REALM), 
                                    MonsterByID(MONSTER_ID_MINOTAUR));

            Location abyss = new Location(LOCATION_ID_ABYSS, "Abyss",
                             "The abode of greedy snakes",
                             ItemByID(ITEM_ID_BLACK_SKELETON), 
                             QuestByID(QUEST_ID_KILL_SNAKE), MonsterByID(MONSTER_ID_SNAKE));
            Location sky_realm = new Location(LOCATION_ID_SKY_REALM, "Sky Realm",
                                 "A place filled with stars under a clear sky, suitable for relaxing after a tiring trip",
                                 null,QuestByID(QUEST_ID_TAKE_STARS));

            Location demon_castle = new Location(LOCATION_ID_DEMON_CASTLE, "Demon Castle",
                                    "A dangerous, and exciting place, perhaps!",
                                    ItemByID(ITEM_ID_ANCIENT_SCROLL), 
                                    QuestByID(QUEST_ID_KILL_FALLEN_ANGEL), 
                                    MonsterByID(MONSTER_ID_FALLEN_ANGEL));

            Location cave_dragon = new Location(LOCATION_ID_CAVE_OF_DRAGON, "Cave of Dragon",
                                    "Do you see the dragons?",
                                    ItemByID(ITEM_ID_DRAGON_EYES), QuestByID(QUEST_ID_MEET_AN_DRAGON));
            Location sea_star = new Location(LOCATION_ID_SEA_OF_STAR, "Sea of Star",
                                "Other location can rest for you!",
                                ItemByID(ITEM_ID_DRAGON_EYES), QuestByID(QUEST_ID_HELP_FOR_DRAGON));
            Location black_mountain = new Location(LOCATION_ID_BLACK_MOUNTAIN, "Black Mountain",
                                        "You can find so more angel in here, but you should careful about this",
                                        ItemByID(ITEM_ID_OLD_CLOCK), QuestByID(QUEST_ID_KILL_GREAT_FALLEN_ANGEL), MonsterByID(MONSTER_ID_GREAT_FALLEN_ANGEL));
            Location aris = new Location(LOCATION_ID_ARIS_RIVER, "Aris River",
                            "A beautiful river, in the past, and now here is Demon King's!",
                            ItemByID(ITEM_ID_SHIELD_OF_THE_SAINT), QuestByID(QUEST_ID_KILL_DEMON_KING), MonsterByID(MONSTER_ID_DEMON_KING));
            //Set map
            home.LocationToEast = abyss;
            home.LocationToNorth = golem_forest;
            golem_forest.LocationToEast = golden_forest;
            golden_forest.LocationToWest = golem_forest;
            golem_forest.LocationToSouth = home;

            abyss.LocationToWest = home;
            abyss.LocationToEast = sky_realm;
            abyss.LocationToSouth = demon_castle;

            sky_realm.LocationToWest = abyss;

            demon_castle.LocationToNorth = abyss;
            demon_castle.LocationToSouth = cave_dragon;

            cave_dragon.LocationToNorth = demon_castle;
            cave_dragon.LocationToSouth = aris;
            cave_dragon.LocationToEast = black_mountain;
            cave_dragon.LocationToWest = sea_star;

            aris.LocationToNorth = cave_dragon;

            black_mountain.LocationToWest = cave_dragon;

            sea_star.LocationToEast = cave_dragon;


            //Add to list
            Locations.Add(home);
            Locations.Add(cave_dragon);
            Locations.Add(aris);
            Locations.Add(black_mountain);
            Locations.Add(sea_star);
            Locations.Add(black_mountain);
            Locations.Add(golem_forest);
            Locations.Add(golden_forest);
            Locations.Add(sky_realm);
            Locations.Add(demon_castle);
        }

        
        public static Item ItemByID(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }
 
        public static Monster MonsterByID(int id)
        {
            foreach (Monster monster in Monsters)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }
            return null;
        }

        public static Quest QuestByID(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }
            return null;
        }

        public static Location LocationByID(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }

            return null;
        }
    }
}

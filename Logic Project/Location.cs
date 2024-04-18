using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Project
{
    public class Location
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public string Descrition { get; set; }
        public Item ItemRequired { get; set; }
        public Quest QuestAvaiable { get; set; }
        public Monster MonsterLivingHere { get; set; }
        public Location LocationToWest { get; set; }
        public Location LocationToNorth { get; set; }
        public Location LocationToSouth { get; set; }
        public Location LocationToEast { get; set; }
        public Location() { }
        public Location(int id, string name, string details, 
                        Item itemRequired = null, Quest questAvaiable = null, 
                           Monster monsterLivingHere = null)
        {
            ID = id;
            Name = name;
            Descrition = details;
            ItemRequired = itemRequired;
            QuestAvaiable = questAvaiable;
            MonsterLivingHere = monsterLivingHere;
        }
    }
}

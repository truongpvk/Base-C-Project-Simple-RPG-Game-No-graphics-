using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Project
{
    public class PlayerQuest
    {
        public Quest Details { get; set; }
        public bool isComplete { get; set; }

        public PlayerQuest() { }
        public PlayerQuest(Quest details, bool isComplete)
        {
            Details = details;
            this.isComplete = isComplete;
        }
    }
}

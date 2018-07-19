using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Composite
{
    public class Group : IPlayer
    {
        public IList<IPlayer> Players = new List<IPlayer>();
        public string Name { get; set; }

        public int Gold
        {
            get { return Players.Sum(x => x.Gold); }
            set
            {
                var toAdd = value / Players.Count;
                foreach (var player in Players)
                {
                    player.Gold += toAdd;
                }
            }
        }

        public void Stats()
        {
            foreach (var player in Players)
            {
                player.Stats();
            }
        }
    }
}
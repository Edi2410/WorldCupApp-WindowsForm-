using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class Player
    {
        public Player(string name, bool captain, int shirtNumber, string position, bool favorite, string teamCode = "")
        {
            Name = name;
            Captain = captain;
            ShirtNumber = shirtNumber;
            Position = position;
            Favorite = favorite;
            TeamCode = teamCode;
        }

        public string Name { get; set; }
        public bool Captain { get; set; }
        public int ShirtNumber { get; set; }
        public string Position { get; set; }
        public bool Favorite { get; set; }
        public string TeamCode { get; set; }
        public string PlayerForChackbox()
            => $"{Name} ({ShirtNumber})";
    }
}

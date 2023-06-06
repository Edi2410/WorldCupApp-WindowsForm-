using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class Visitors
    {
        public Visitors(int visitorNumber, string location, string home, string away)
        {
            VisitorNumber = visitorNumber;
            Location = location;
            Home = home;
            Away = away;
        }

        public int VisitorNumber { get; set; }
        public string Location { get; set; }
        public string Home { get; set; }
        public string Away { get; set; }

        public string GetVisitorInfo()
            => $"{VisitorNumber}, {Location}, {Home}, {Away}";
    }
}

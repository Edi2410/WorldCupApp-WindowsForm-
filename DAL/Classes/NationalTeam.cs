using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class NationalTeam
    {
        public NationalTeam(int id, string country, string alternateName, string fifaCode, int groupId, char groupLetter)
        {
            Id = id;
            Country = country;
            AlternateName = alternateName;
            FifaCode = fifaCode;
            GroupId = groupId;
            GroupLetter = groupLetter;
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public string AlternateName { get; set; }
        public string FifaCode { get; set; }
        public int GroupId { get; set; }
        public char GroupLetter { get; set; }

        public string NationalTeamForChose() => $"{Country} ({FifaCode})";
    }
}

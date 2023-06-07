using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Classes
{
    public class NationalTeam
    {
        public NationalTeam(int id, string country, string alternateName, string fifaCode, int groupId, char groupLetter, int gamePlayed, int gameWins, int gameDraws, int gameLosses, int goalsFor, int goalsAgainst, int goalsDiferential)
        {
            Id = id;
            Country = country;
            AlternateName = alternateName;
            FifaCode = fifaCode;
            GroupId = groupId;
            GroupLetter = groupLetter;
            GamePlayed = gamePlayed;
            GameWins = gameWins;
            GameDraws = gameDraws;
            GameLosses = gameLosses;
            GoalsFor = goalsFor;
            GoalsAgainst = goalsAgainst;
            GoalsDiferential = goalsDiferential;
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public string AlternateName { get; set; }
        public string FifaCode { get; set; }
        public int GroupId { get; set; }
        public char GroupLetter { get; set; }
        public int GamePlayed { get; set; }
        public int GameWins { get; set; }
        public int GameDraws { get; set; }
        public int GameLosses { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalsDiferential { get; set; }


        public string NationalTeamForChose() => $"{Country} ({FifaCode})";
    }
}

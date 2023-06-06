﻿using DAL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL.RepoFactory
{
    public interface IRepo
    {
        void SaveUsersSettings(string language, string worldCup, string path);
        void SaveChosenNationalTeam(string team, string path);
        void SaveFavoritePlayes(List<string> players, string path);
        List<NationalTeam> GetNationalTeams();
        List<NationalTeam> GetEnemyTeams();
        List <Player> GetPlayers();
        List<Event> GetPlayerStatsData();
        List<Visitors> GetVisitorsStatsData();
        string GetResults(NationalTeam homeTeam, NationalTeam awayTeam);
        string[] GetFavoritePlayers();
        string GetWorldCup();
        string GetFifaCode();
        int GetWidth();
        int GetHeight();
    }
}

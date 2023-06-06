using DAL.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace DAL.RepoFactory
{
    internal class FileRepo : IRepo
    {
        private static string SETTINGS_PATH = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName, "settings.txt");
        private static string WPF_SETTINGS_PATH = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName, "wpf_settings.txt");
        private static string FAVORITETEAM_PATH = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName, "favorite_team.txt");
        private static string FAVORITEPLAYER_PATH = Path.Combine(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).Parent.FullName, "favorite_player.txt");


        public void SaveUsersSettings(string language, string worldCup, string path)
        {
            File.WriteAllText(path, $"{language},{worldCup}");
        }

        public void SaveChosenNationalTeam(string chosenTeam, string path)
        {
            File.WriteAllText(path, $"{chosenTeam}");
        }
        public void SaveFavoritePlayes(List<string> players, string path)
        {
            File.WriteAllLines(path, players);
        }

        public List<NationalTeam> GetNationalTeams()
        {
            JArray jsonTeamData = new JArray();


            if (GetWorldCup() == "Musko")
            {
                 jsonTeamData = FatchData("https://worldcup-vua.nullbit.hr/men/teams/results");
            }
            else
            {
                 jsonTeamData = FatchData("https://worldcup-vua.nullbit.hr/women/teams/results");
            }

            List<NationalTeam> listTeamData = new List<NationalTeam>();
            foreach (var team in jsonTeamData)
            {
                listTeamData.Add(new NationalTeam(
                    team.Value<int>("id"),
                    team.Value<string>("country"),
                    team.Value<string>("alternate_name"),
                    team.Value<string>("fifa_code"),
                    team.Value<int>("group_id"),
                    team.Value<string>("group_letter")[0]
                ));
            }
        
            return listTeamData;
        }


        public List<Player> GetPlayers()
        {
            JArray jsonPlayerData = new JArray();


            if (GetWorldCup() == "Musko")
            {
                jsonPlayerData = FatchData($"https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code={GetFifaCode()}");
            }
            else
            {
                jsonPlayerData = FatchData($"https://worldcup-vua.nullbit.hr/women/matches/country?fifa_code={GetFifaCode()}");
            }

            List<Player> listPlayersData = new List<Player>();

            JArray unionArray = new JArray();

            if((jsonPlayerData[0]["home_team"]).Value<string>("code") == GetFifaCode())
            {
                unionArray = new JArray((jsonPlayerData[0]["home_team_statistics"]["starting_eleven"]).Union((JArray)jsonPlayerData[0]["home_team_statistics"]["substitutes"]));
            }
            else
            {
                unionArray = new JArray((jsonPlayerData[0]["away_team_statistics"]["starting_eleven"]).Union((JArray)jsonPlayerData[0]["away_team_statistics"]["substitutes"]));
            }

            foreach (var player in unionArray)
            {
                listPlayersData.Add(new Player(
                       player.Value<string>("name"),
                       player.Value<bool>("captain"),
                       player.Value<int>("shirt_number"),
                       player.Value<string>("position"),
                       false
                ));
            }

            return listPlayersData;
        }

        public List<Event> GetPlayerStatsData()
        {
            JArray jsonStatsData = new JArray();
            List<Event> eventList = new List<Event>();


            if (GetWorldCup() == "Musko")
            {
                jsonStatsData = FatchData($"https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code={GetFifaCode()}");
            }
            else
            {
                jsonStatsData = FatchData($"https://worldcup-vua.nullbit.hr/women/matches/country?fifa_code={GetFifaCode()}");
            }

            foreach (var match in jsonStatsData) {
                if ((match["home_team"]).Value<string>("code") == GetFifaCode())
                {
                    eventList = ValidEvent((JArray)match["home_team_events"]);
                }
                else
                {
                    eventList = ValidEvent((JArray)match["away_team_events"]);
                }
            }

            return eventList;
        }

        public List<NationalTeam> GetEnemyTeams()
        {
            JArray jsonMatchData = new JArray();
            JArray jsonNationalsTeamsData = new JArray();
            List<string> codeList = new List<string>();
            List<NationalTeam> enemyTeamsList = new List<NationalTeam>();

            if (GetWorldCup() == "Musko")
            {
                jsonMatchData = FatchData($"https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code={GetFifaCode()}");
                jsonNationalsTeamsData = FatchData("https://worldcup-vua.nullbit.hr/men/teams/results");
            }
            else
            {
                jsonMatchData = FatchData($"https://worldcup-vua.nullbit.hr/women/matches/country?fifa_code={GetFifaCode()}");
                jsonNationalsTeamsData = FatchData("https://worldcup-vua.nullbit.hr/women/teams/results");
            }

            foreach (var match in jsonMatchData)
            {
                if ((match["home_team"]).Value<string>("code") == GetFifaCode())
                {
                    codeList.Add((match["away_team"]).Value<string>("code"));
                }
                else
                {
                    codeList.Add((match["home_team"]).Value<string>("code"));
                }
            }

            foreach (var nationalteam in jsonNationalsTeamsData)
            {
                if (codeList.Contains(nationalteam.Value<String>("fifa_code")))
                {
                    enemyTeamsList.Add(new NationalTeam(
                        nationalteam.Value<int>("id"),
                        nationalteam.Value<string>("country"),
                        nationalteam.Value<string>("alternate_name"),
                        nationalteam.Value<string>("fifa_code"),
                        nationalteam.Value<int>("group_id"),
                        nationalteam.Value<string>("group_letter")[0]
                        ));
                }
            }

            return enemyTeamsList;


        }

        public List<Visitors> GetVisitorsStatsData()
        {
            JArray jsonStatsData = new JArray();
            List<Visitors> listVisitorsStats =  new List<Visitors>();

            if (GetWorldCup() == "Musko")
            {
                jsonStatsData = FatchData($"https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code={GetFifaCode()}");
            }
            else
            {
                jsonStatsData = FatchData($"https://worldcup-vua.nullbit.hr/women/matches/country?fifa_code={GetFifaCode()}");
            }

            foreach (var match in jsonStatsData)
            {
                listVisitorsStats.Add(new Visitors(
                    match.Value<int>("attendance"),
                    match.Value<string>("location"),
                    match.Value<string>("home_team_country"),
                    match.Value<string>("away_team_country")
                ));
            }

            return listVisitorsStats.OrderByDescending(visitor => visitor.VisitorNumber).ToList();
        }

        public string GetResults(NationalTeam homeTeam, NationalTeam awayTeam)
        {
            JArray jsonMatchData = new JArray();
            List<Event> eventList = new List<Event>();
            

            if (GetWorldCup() == "Musko")
            {
                jsonMatchData = FatchData($"https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code={homeTeam.FifaCode}");
            }
            else
            {
                jsonMatchData = FatchData($"https://worldcup-vua.nullbit.hr/women/matches/country?fifa_code={homeTeam.FifaCode}");
            }
            foreach (var match in jsonMatchData)
            {
                if ((match["away_team"]).Value<string>("code") == awayTeam.FifaCode)
                {
                    return $"{(match["home_team"]).Value<string>("goals")} : {(match["away_team"]).Value<string>("goals")}";
                }
                else if ((match["home_team"]).Value<string>("code") == awayTeam.FifaCode)
                {
                    return $"{(match["away_team"]).Value<string>("goals")} : {(match["home_team"]).Value<string>("goals")}";
                }
            }

            return "0 : 0";
        }

        private List<Event> ValidEvent(JToken matchEvent)
        {
            List<Event> validEvents = new List<Event> ();
            foreach (var Event  in matchEvent)
            {
                if (Event.Value<string>("type_of_event") == "yellow-card" || Event.Value<string>("type_of_event") == "goal")
                {
                    validEvents.Add(new Event(
                        Event.Value<string>("type_of_event"),
                        Event.Value<string>("player")
                    ));
                }
            }
            return validEvents;
        }

        public string[] GetFavoritePlayers()
        {
            try
            {
                if (File.Exists(FAVORITEPLAYER_PATH))
                {
                    return File.ReadAllLines(FAVORITEPLAYER_PATH);

                }
                MessageBox.Show("Ne možemo pronaći datoteku ponovo pokrenite aplikaciju", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new FileNotFoundException("Ne možemo pronaći datoteku ponovo pokrenite aplikaciju");
            }
            catch (FileNotFoundException) {
                MessageBox.Show("Ne možemo pronaći datoteku ponovo pokrenite aplikaciju", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }


        }

        public string GetWorldCup()
        {
            try
            {
                if (File.Exists(SETTINGS_PATH))
                {
                    string[] settings = File.ReadAllLines(SETTINGS_PATH);
                    if (settings.Length > 0)
                    {
                        string[] parts = settings[0].Split(',');
                        string[] gender = parts[1].Split(' ');
                        return gender[0];
                    }
                }
                throw new FileNotFoundException("Ne možemo pronaći datoteku ponovo pokrenite aplikaciju");
            }
            catch (Exception) {
                MessageBox.Show("Ne možemo pronaći datoteku ponovo pokrenite aplikaciju", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            
        }

        public string GetFifaCode()
        {
            try
            {
                if (File.Exists(FAVORITETEAM_PATH))
                {
                    string[] settings = File.ReadAllLines(FAVORITETEAM_PATH);
                    if (settings.Length > 0)
                    {
                        string[] parts = settings[0].Split('(');
                        string[] gender = parts[1].Split(')');
                        return gender[0];
                    }
                }
                throw new FileNotFoundException("Ne možemo pronaći datoteku ponovo pokrenite aplikaciju");
            }
            catch (Exception)
            {
                MessageBox.Show("Ne možemo pronaći datoteku ponovo pokrenite aplikaciju", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }



        private JArray FatchData(string url)
        {
            try
            {
                var client = new HttpClient();
                var content = (client.GetAsync(url).Result).Content.ReadAsStringAsync().Result;
                JArray jsonData = JArray.Parse(content);
                return jsonData;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new JArray();
            }
        }

        public int GetWidth()
        {
            try
            {
                if (File.Exists(WPF_SETTINGS_PATH))
                {
                    string[] settings = File.ReadAllLines(WPF_SETTINGS_PATH);
                    if (settings.Length > 0)
                    {
                        string size = settings[0].Split(',')[2];
                        if(size == "Manji")
                        {
                            return 400;
                        }else if (size == "Srednji")
                        {
                            return 800;
                        }
                        else
                        {
                            return 999999;
                        }
                    }
                }
                throw new FileNotFoundException("Ne možemo pronaći datoteku ponovo pokrenite aplikaciju");
            }
            catch (Exception)
            {
                MessageBox.Show("Ne možemo pronaći datoteku ponovo pokrenite aplikaciju", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int GetHeight()
        {
            try
            {
                if (File.Exists(WPF_SETTINGS_PATH))
                {
                    string[] settings = File.ReadAllLines(WPF_SETTINGS_PATH);
                    if (settings.Length > 0)
                    {
                        string size = settings[0].Split(',')[2];
                        if (size == "Manji")
                        {
                            return 400;
                        }
                        else if (size == "Srednji")
                        {
                            return 800;
                        }
                        else
                        {
                            return 999999;
                        }
                    }
                }
                throw new FileNotFoundException("Ne možemo pronaći datoteku ponovo pokrenite aplikaciju");
            }
            catch (Exception)
            {
                MessageBox.Show("Ne možemo pronaći datoteku ponovo pokrenite aplikaciju", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }


    }
}

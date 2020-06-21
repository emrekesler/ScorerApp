using System;
using System.Collections.Generic;
using System.Text;

namespace ScorerApp.FootballDataProvider.Items
{
    public class Match
    {
        public int MatchId { get; set; }
        public string LeagueName { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public string Status { get; set; }
        public string Score { get; set; }
    }

}

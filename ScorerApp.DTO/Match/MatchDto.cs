using ScorerApp.DTO.League;
using ScorerApp.DTO.Team;
using System;
namespace ScorerApp.DTO.Match
{
    public class MatchDto : BaseDto
    {
        public int DataProviderMatchId { get; set; }
        public TeamDto HomeTeam { get; set; }
        public int HomeTeamId { get; set; }
        public TeamDto AwayTeam { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public DateTime StartDate { get; set; }
        public int LeagueId { get; set; }
        public LeagueDto League { get; set; }
        public string Status { get; set; }
    }
}

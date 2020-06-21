using Core.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ScorerApp.Entity.Entities
{
    public class Match : BaseEntity
    {
        public int DataProviderMatchId { get; set; }
        public Team HomeTeam { get; set; }
        public int HomeTeamId { get; set; }
        public Team AwayTeam { get; set; }
        public int AwayTeamId { get; set; }
        public DateTime StartDate { get; set; }
        public int LeagueId { get; set; }
        public League League { get; set; }

        //Enum veya Table'a çevirebilir. 
        [MaxLength(30)]
        public string Status { get; set; }
        public string Score { get; set; }
    }
}

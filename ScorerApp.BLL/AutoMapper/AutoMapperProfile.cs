using AutoMapper;
using ScorerApp.DTO.League;
using ScorerApp.DTO.Match;
using ScorerApp.DTO.Team;
using ScorerApp.Entity.Entities;

namespace ScorerApp.BLL.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Match, MatchDto>().ReverseMap();
            CreateMap<League, LeagueDto>().ReverseMap();
            CreateMap<Team, TeamDto>().ReverseMap();
        }
    }
}

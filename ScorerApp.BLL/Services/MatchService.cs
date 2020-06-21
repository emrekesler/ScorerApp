using AutoMapper;
using Core.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Logging;
using ScorerApp.BLL.Services.Interfaces;
using ScorerApp.DTO.Match;
using ScorerApp.Entity.Entities;
using ScorerApp.FootballDataProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ScorerApp.BLL.Services
{
    public class MatchService : ServiceBase<Match>, IMatchService
    {
        private readonly IFootballDataProvider _footballDataProvider;
        private readonly ITeamService _teamService;
        private readonly ILeagueService _leagueService;
        public MatchService(DbContext dbContext, ILogger<ServiceBase<Match>> logger, IMapper mapper, IFootballDataProvider footballDataProvider, ITeamService teamService, ILeagueService leagueService) : base(dbContext, logger, mapper)
        {
            _footballDataProvider = footballDataProvider;
            _teamService = teamService;
            _leagueService = leagueService;
        }

        public Response<MatchDto> Get(int Id)
        {
            try
            {
                Match match = _dbSet.Include(m => m.HomeTeam).Include(m => m.AwayTeam).Include(m => m.League).SingleOrDefault(m => m.DataProviderMatchId == Id);

                if (match != null)
                    return new Response<MatchDto>(_mapper.Map<MatchDto>(match), true);
                else
                    return new Response<MatchDto>(isSuccess: true);
            }
            catch (Exception ex)
            {
                Log(ex);
                return new Response<MatchDto>();
            }
        }

        public Response<List<MatchDto>> Get(DateTime date)
        {
            try
            {
                List<Match> matches = GetMatches(date);

                if (!matches.Any())
                {
                    GenerateDailyMatches(date);
                }

                matches = GetMatches(date);

                return new Response<List<MatchDto>>(_mapper.Map<List<MatchDto>>(matches), true);

            }
            catch (Exception ex)
            {
                Log(ex);
                return new Response<List<MatchDto>>();
            }
        }

        private void GenerateDailyMatches(DateTime date)
        {
            var dpMatches = _footballDataProvider.GetMatches(date.Date);

            foreach (var item in dpMatches)
            {
                Match match = new Match
                {
                    AwayTeamId = _teamService.GetId(item.AwayTeamName),
                    HomeTeamId = _teamService.GetId(item.HomeTeamName),
                    Score = item.Score,
                    Status = item.Status,
                    DataProviderMatchId = item.MatchId,
                    LeagueId = _leagueService.GetId(item.LeagueName),
                    StartDate = date.Date
                };

                _dbSet.Add(match);
            }

            SaveChanges();
        }

        private List<Match> GetMatches(DateTime date)
        {
            return _dbSet.Where(match => match.StartDate == date.Date).Include(m => m.HomeTeam).Include(m => m.AwayTeam).Include(m => m.League).ToList();
        }

        public Response<MatchDto> Get(int Id, DateTime date)
        {
            try
            {
                Match match = _dbSet.Where(match => match.DataProviderMatchId == Id && match.StartDate == date.Date).Include(m => m.HomeTeam).Include(m => m.AwayTeam).Include(m => m.League).SingleOrDefault();

                if (match != null)
                {
                    return new Response<MatchDto>(_mapper.Map<MatchDto>(match), true);
                }
                else
                {
                    return new Response<MatchDto>(isSuccess: true);

                }
            }
            catch (Exception ex)
            {
                Log(ex);
                return new Response<MatchDto>();
            }
        }
    }
}

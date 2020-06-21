using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScorerApp.BLL.Services.Interfaces;
using ScorerApp.Entity.Entities;
using System;
using System.Linq;

namespace ScorerApp.BLL.Services
{
    public class LeagueService : ServiceBase<League>, ILeagueService
    {
        public LeagueService(DbContext dbContext, ILogger<ServiceBase<League>> logger, IMapper mapper) : base(dbContext, logger, mapper)
        {
        }

        public League Add(string name)
        {
            try
            {
                League league = new League { Name = name };
                _dbSet.Add(league);

                if (SaveChanges())
                    return league;
                else
                    return null;
            }
            catch (Exception ex)
            {
                Log(ex);
                return null;
            }
        }

        public League Get(string name)
        {
            try
            {
                return _dbSet.Where(league => league.Name == name).Single();
            }
            catch (Exception ex)
            {
                Log(ex);
                return null;
            }
        }

        public int GetId(string name)
        {
            try
            {
                League league = Get(name);
                if (league == null)
                    return Add(name).Id;
                else
                    return league.Id;
            }
            catch (Exception ex)
            {
                Log(ex);
                return 0;
            }
        }
    }
}

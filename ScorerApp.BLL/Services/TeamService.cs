using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScorerApp.BLL.Services.Interfaces;
using ScorerApp.Entity.Entities;
using System;
using System.Linq;

namespace ScorerApp.BLL.Services
{
    public class TeamService : ServiceBase<Team>, ITeamService
    {
        public TeamService(DbContext dbContext, ILogger<ServiceBase<Team>> logger, IMapper mapper) : base(dbContext, logger, mapper)
        {
        }

        public Team Add(string name)
        {
            try
            {
                Team team = new Team { Name = name };
                _dbSet.Add(team);

                if (SaveChanges())
                    return team;
                else
                    return null;
            }
            catch (Exception ex)
            {
                Log(ex);
                return null;
            }
        }

        public Team Get(string name)
        {
            try
            {
                return _dbSet.Where(team => team.Name == name).Single();
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
                Team team = Get(name);
                if (team == null)
                    return Add(name).Id;
                else
                    return team.Id;
            }
            catch (Exception ex)
            {
                Log(ex);
                return 0;
            }
        }
    }   
}
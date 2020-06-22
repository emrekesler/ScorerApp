using AutoMapper;
using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace ScorerApp.BLL.Services
{
    public class ServiceBase<T> where T : BaseEntity
    {
        protected readonly ILogger _logger;
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;
        protected readonly IMapper _mapper;

        public ServiceBase(DbContext dbContext, ILogger<ServiceBase<T>> logger, IMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            _mapper = mapper;
        }
        public bool SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Log(ex);
                return false;
            }
        }

        public void Log(Exception ex)
        {
            _logger.LogError(ex, "{@Exception}", ex);
        }
    }
}

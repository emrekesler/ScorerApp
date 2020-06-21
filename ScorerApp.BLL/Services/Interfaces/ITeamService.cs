using ScorerApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScorerApp.BLL.Services.Interfaces
{
    public interface ITeamService
    {
        int GetId(string name);
        Team Get(string name);
        Team Add(string name);
    }
}

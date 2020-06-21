using ScorerApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScorerApp.BLL.Services.Interfaces
{
    public interface ILeagueService
    {
        int GetId(string name);
        League Get(string name);
        League Add(string name);
    }
}

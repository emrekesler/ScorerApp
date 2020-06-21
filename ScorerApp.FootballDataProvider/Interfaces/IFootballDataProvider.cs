using ScorerApp.FootballDataProvider.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScorerApp.FootballDataProvider.Interfaces
{
    public interface IFootballDataProvider
    {
        List<Match> GetMatches(DateTime date);
    }
}

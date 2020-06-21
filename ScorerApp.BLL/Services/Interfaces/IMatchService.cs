using Core.Response;
using ScorerApp.DTO.Match;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScorerApp.BLL.Services.Interfaces
{
    public interface IMatchService
    {
        Response<MatchDto> Get(int Id);
        Response<List<MatchDto>> Get(DateTime date);
        Response<MatchDto> Get(int Id, DateTime date);
    }
}
